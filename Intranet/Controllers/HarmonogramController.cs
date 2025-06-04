using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Intranet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Controllers
{
    [Authorize]
    public class HarmonogramController : Controller
    {
        private readonly IntranetContext _db;

        public HarmonogramController(IntranetContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int? month, int? year)
        {
            var m = month ?? DateTime.Now.Month;
            var y = year ?? DateTime.Now.Year;

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                // Rozważ odpowiednią obsługę błędu, np. return Unauthorized();
                // lub przekierowanie do strony błędu/logowania.
                // Na razie, dla uproszczenia, można rzucić wyjątek lub zwrócić błąd.
                // W praktyce produkcyjnej lepiej obsłużyć to bardziej elegancko.
                return BadRequest("Nie można zidentyfikować użytkownika.");
            }

            var zmiany = await _db.Harmonogramies
                .Where(h => h.PracownikId == userId &&
                            h.DataZmiany.Month == m &&
                            h.DataZmiany.Year == y)
                .ToListAsync();

            var vm = new HarmonogramViewModel
            {
                Month = m,
                Year = y,
                Zmiany = zmiany
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new Harmonogramy
            {
                DataZmiany = DateOnly.FromDateTime(DateTime.Today)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Harmonogramy harmonogramEntry)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                ModelState.AddModelError(string.Empty, "Nie można zidentyfikować użytkownika.");
                return View(harmonogramEntry);
            }

            harmonogramEntry.PracownikId = userId;

            if (ModelState.IsValid)
            {
                _db.Harmonogramies.Add(harmonogramEntry);
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Nowa zmiana została pomyślnie dodana.";
                return RedirectToAction(nameof(Index), new { month = harmonogramEntry.DataZmiany.Month, year = harmonogramEntry.DataZmiany.Year });
            }

            return View(harmonogramEntry);
        }
    }

    public class HarmonogramViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public List<Harmonogramy> Zmiany { get; set; } = new();
    }
}
