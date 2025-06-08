
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
    [Authorize]
    public class ZadaniaController : Controller
    {
        private readonly IntranetContext _context;

        public ZadaniaController(IntranetContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleWykonane(int id)
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

            if (zadanie.PracownikId != currentUserId && !User.IsInRole("Admin"))
            {
                return Forbid("Nie masz uprawnień do modyfikacji tego zadania.");
            }

            zadanie.CzyWykonane = !zadanie.CzyWykonane;
            if (zadanie.CzyWykonane)
            {
                zadanie.DataWykonania = DateTime.UtcNow;
            }
            else
            {
                zadanie.DataWykonania = null;
            }

            _context.Update(zadanie);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Create()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                TempData["ErrorMessage"] = "Nie można zidentyfikować użytkownika. Zaloguj się ponownie.";
                return RedirectToAction("Index", "Home");
            }

            var model = new Zadanie
            {
                PracownikId = userId,
                DataUtworzenia = DateTime.UtcNow,
                TerminWykonania = DateTime.Today.AddDays(7)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tytul,Opis,TerminWykonania,Priorytet,PracownikId")] Zadanie zadanie)
        {
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
                return RedirectToAction("Index", "Home");
            }
            return View(zadanie);
        }


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

            if (zadanie.PracownikId != currentUserId && !User.IsInRole("Admin"))
            {
                return Forbid("Nie masz uprawnień do usunięcia tego zadania.");
            }


            _context.Zadania.Remove(zadanie);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Zadanie zostało usunięte.";
            return RedirectToAction("Index", "Home");
        }
    }
}
