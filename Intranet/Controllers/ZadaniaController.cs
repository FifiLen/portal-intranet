// W Controllers/ZadaniaController.cs
using Intranet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Intranet.Controllers
{
    [Authorize] // Wszystkie akcje w tym kontrolerze wymagają autoryzacji
    public class ZadaniaController : Controller
    {
        private readonly IntranetContext _context;

        public ZadaniaController(IntranetContext context)
        {
            _context = context;
        }

        // Akcja do przełączania statusu CzyWykonane zadania
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleWykonane(int id)
        {
            var zadanie = await _context.Zadania.FindAsync(id);

            if (zadanie == null)
            {
                return NotFound();
            }

            // Sprawdzenie, czy zalogowany użytkownik jest właścicielem zadania
            // lub czy jest adminem (opcjonalna dodatkowa weryfikacja)
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdString, out var currentUserId))
            {
                return Unauthorized("Nie można zidentyfikować użytkownika.");
            }

            if (zadanie.PracownikId != currentUserId && !User.IsInRole("Admin"))
            {
                return Forbid("Nie masz uprawnień do modyfikacji tego zadania.");
            }

            zadanie.CzyWykonane = !zadanie.CzyWykonane; // Przełącz status
            if (zadanie.CzyWykonane)
            {
                zadanie.DataWykonania = DateTime.UtcNow; // Ustaw datę wykonania
            }
            else
            {
                zadanie.DataWykonania = null; // Usuń datę wykonania, jeśli oznaczono jako niewykonane
            }

            _context.Update(zadanie);
            await _context.SaveChangesAsync();

            // Przekieruj z powrotem do strony, z której przyszło żądanie (np. dashboard)
            // Można też użyć Request.Headers["Referer"].ToString() jeśli jest dostępne i bezpieczne
            return RedirectToAction("Index", "Home");
        }


        // GET: Zadania/Create (dla dodawania nowego zadania - zrobimy to później)
        public IActionResult Create()
        {
            // Pobierz ID zalogowanego użytkownika, aby przypisać zadanie
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                // Obsłuż błąd - użytkownik musi być zalogowany, aby dodać zadanie dla siebie
                TempData["ErrorMessage"] = "Nie można zidentyfikować użytkownika. Zaloguj się ponownie.";
                return RedirectToAction("Index", "Home");
            }

            var model = new Zadanie
            {
                PracownikId = userId, // Domyślnie przypisz do zalogowanego użytkownika
                DataUtworzenia = DateTime.UtcNow,
                TerminWykonania = DateTime.Today.AddDays(7) // Domyślny termin np. za tydzień
            };
            return View(model);
        }

        // POST: Zadania/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tytul,Opis,TerminWykonania,Priorytet,PracownikId")] Zadanie zadanie)
        {
            // Upewnij się, że PracownikId jest ustawione (np. z ukrytego pola lub pobrane z claimów)
            // Jeśli PracownikId nie jest w [Bind], ustaw je tutaj:
            if (zadanie.PracownikId == 0)
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out var userId))
                {
                    zadanie.PracownikId = userId;
                }
                else
                {
                    ModelState.AddModelError("PracownikId", "Nie można przypisać zadania do użytkownika.");
                }
            }

            zadanie.DataUtworzenia = DateTime.UtcNow;
            zadanie.CzyWykonane = false;


            if (ModelState.IsValid)
            {
                _context.Add(zadanie);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Nowe zadanie zostało pomyślnie dodane.";
                return RedirectToAction("Index", "Home"); // Wróć do dashboardu
            }
            // Jeśli model nie jest poprawny, wróć do formularza z błędami
            return View(zadanie);
        }


        // POST: Zadania/Delete/5 (dla usuwania zadania)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var zadanie = await _context.Zadania.FindAsync(id);
            if (zadanie == null)
            {
                return NotFound();
            }

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdString, out var currentUserId))
            {
                return Unauthorized("Nie można zidentyfikować użytkownika.");
            }

            // Tylko właściciel zadania lub admin może je usunąć
            if (zadanie.PracownikId != currentUserId && !User.IsInRole("Admin"))
            {
                return Forbid("Nie masz uprawnień do usunięcia tego zadania.");
            }

            // Dodatkowa logika: np. pozwól usuwać tylko wykonane zadania
            // if (!zadanie.CzyWykonane && !User.IsInRole("Admin"))
            // {
            //     TempData["ErrorMessage"] = "Można usuwać tylko wykonane zadania.";
            //     return RedirectToAction("Index", "Home");
            // }

            _context.Zadania.Remove(zadanie);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Zadanie zostało usunięte.";
            return RedirectToAction("Index", "Home");
        }
    }
}
