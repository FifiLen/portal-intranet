using Intranet.Models; // Upewnij się, że ten using jest dla IntranetContext, Urlopy, UrlopStatus
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore; // Dla .Include(), .ToListAsync(), .FindAsync()
using System.Linq;                 // Dla .AsQueryable(), .Where(), .OrderBy()
using System.Threading.Tasks;    // Dla async/await

namespace Intranet.Controllers
{
    [Authorize] // Wszystkie akcje w tym kontrolerze wymagają autoryzacji
    public class UrlopController : Controller
    {
        private readonly IntranetContext _db; // Wstrzyknięty DbContext

        // Usunięto: public object UrlopStatus { get; private set; }

        public UrlopController(IntranetContext db)
        {
            _db = db;
        }

        // GET: /Urlop lub /Urlop/Index
        public async Task<IActionResult> Index()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Bezpieczne parsowanie ID użytkownika
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                // Jeśli ID użytkownika nie jest dostępne lub nie jest poprawną liczbą,
                // można zwrócić błąd lub przekierować do strony logowania.
                // Unauthorized() może być odpowiednie, jeśli użytkownik powinien być zalogowany.
                return Unauthorized("Nie można zidentyfikować użytkownika.");
            }

            var isAdmin = User.IsInRole("Admin"); // Sprawdzenie, czy użytkownik ma rolę Admin

            // Pobieranie urlopów z bazy danych
            // Używamy _db.Urlopies (zgodnie z nazwą DbSet w IntranetContext)
            IQueryable<Urlopy> query = _db.Urlopies
                                          .Include(u => u.Pracownik); // Dołączamy dane pracownika

            if (!isAdmin)
            {
                // Zwykły użytkownik widzi tylko swoje urlopy
                query = query.Where(u => u.PracownikId == userId);
            }

            // Sortowanie i pobranie listy
            var urlopyList = await query.OrderBy(u => u.DataOd).ToListAsync();

            return View(urlopyList); // Przekazanie listy urlopów do widoku
        }

        // GET: /Urlop/Create
        public IActionResult Create()
        {
            // Zwraca widok do tworzenia nowego urlopu.
            // Można tu przekazać pusty model lub dane do list rozwijanych, jeśli są potrzebne.
            return View(new Urlopy()); // Przekazanie nowego obiektu Urlopy, aby formularz był silnie typowany
        }

        // POST: /Urlop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Urlopy urlopViewModel) // Model z danymi z formularza
        {
            // Sprawdzenie, czy model przeszedł walidację (np. atrybuty [Required])
            if (ModelState.IsValid)
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
                {
                    ModelState.AddModelError(string.Empty, "Nie można zidentyfikować użytkownika.");
                    return View(urlopViewModel); // Wróć do formularza z błędem
                }

                // Ustawienie pól, które nie pochodzą bezpośrednio z formularza
                urlopViewModel.PracownikId = userId;
                urlopViewModel.Status = Models.UrlopStatus.Oczekuje; // Użycie enuma

                _db.Urlopies.Add(urlopViewModel); // Dodanie nowego urlopu do DbContext
                await _db.SaveChangesAsync();   // Zapisanie zmian w bazie danych

                return RedirectToAction(nameof(Index)); // Przekierowanie do listy urlopów
            }
            return View(urlopViewModel); // Jeśli model nie jest poprawny, wróć do formularza z błędami walidacji
        }

        // POST: /Urlop/Approve/5
        [Authorize(Roles = "Admin")] // Tylko Admin może zatwierdzać
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id) // ID urlopu do zatwierdzenia
        {
            var urlop = await _db.Urlopies.FindAsync(id); // Znajdź urlop w bazie

            if (urlop != null && urlop.Status == Models.UrlopStatus.Oczekuje) // Sprawdź, czy istnieje i czy status to Oczekuje
            {
                urlop.Status = Models.UrlopStatus.Zaakceptowany; // Zmień status na Zaakceptowany
                await _db.SaveChangesAsync();                  // Zapisz zmiany
            }
            // Można dodać TempData lub ViewBag z komunikatem o sukcesie/błędzie
            return RedirectToAction(nameof(Index));
        }

        // POST: /Urlop/Reject/5
        [Authorize(Roles = "Admin")] // Tylko Admin może odrzucać
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id) // ID urlopu do odrzucenia
        {
            var urlop = await _db.Urlopies.FindAsync(id); // Znajdź urlop w bazie

            if (urlop != null && urlop.Status == Models.UrlopStatus.Oczekuje) // Sprawdź, czy istnieje i czy status to Oczekuje
            {
                urlop.Status = Models.UrlopStatus.Odrzucony; // Zmień status na Odrzucony
                await _db.SaveChangesAsync();                // Zapisz zmiany
            }
            // Można dodać TempData lub ViewBag z komunikatem o sukcesie/błędzie
            return RedirectToAction(nameof(Index));
        }
    }
}
