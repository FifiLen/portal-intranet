using Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Może być potrzebne, jeśli będziesz robić bardziej złożone operacje
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; // Jeśli chcesz ograniczyć dostęp

namespace Intranet.Controllers
{
    [Authorize(Roles = "Admin")] // Tylko Admin może zarządzać ogłoszeniami (przykład)
    public class OgloszeniaController : Controller
    {
        private readonly IntranetContext _context;

        public OgloszeniaController(IntranetContext context)
        {
            _context = context;
        }

        // GET: Ogloszenia/Create
        public IActionResult Create()
        {
            // Możemy przekazać domyślne wartości, np. bieżącą datę
            var model = new Ogloszenie
            {
                DataPublikacji = DateTime.Today // Domyślnie dzisiejsza data
            };
            return View(model);
        }

        // POST: Ogloszenia/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Tytul,Tresc,DataPublikacji,Dzial,Typ,CzyWazne")] Ogloszenie ogloszenie)
        {
            // Możesz chcieć ustawić DataPublikacji na serwerze, jeśli nie ufasz dacie od klienta
            // ogloszenie.DataPublikacji = DateTime.UtcNow;

            if (ModelState.IsValid)
            {
                _context.Add(ogloszenie);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Ogłoszenie zostało pomyślnie dodane.";
                // Przekieruj np. do listy ogłoszeń (jeśli ją stworzysz) lub z powrotem do dashboardu
                return RedirectToAction("Index", "Home"); // Na razie wracamy do dashboardu
            }
            // Jeśli model nie jest poprawny, wróć do formularza z błędami
            return View(ogloszenie);
        }

        // Możesz tu później dodać akcje Index (do listowania wszystkich ogłoszeń), Edit, Delete itp.
    }
}
