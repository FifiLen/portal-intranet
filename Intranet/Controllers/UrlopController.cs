using Intranet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Controllers
{
    [Authorize]
    public class UrlopController : Controller
    {
        private readonly IntranetContext _db;


        public UrlopController(IntranetContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                return Unauthorized("Nie można zidentyfikować użytkownika.");
            }

            var isAdmin = User.IsInRole("Admin");

            IQueryable<Urlopy> query = _db.Urlopies
                                          .Include(u => u.Pracownik);

            if (!isAdmin)
            {
                query = query.Where(u => u.PracownikId == userId);
            }

            var urlopyList = await query.OrderBy(u => u.DataOd).ToListAsync();

            return View(urlopyList);
        }

        public IActionResult Create()
        {
            return View(new Urlopy());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Urlopy urlopViewModel)
        {
            if (ModelState.IsValid)
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
                {
                    ModelState.AddModelError(string.Empty, "Nie można zidentyfikować użytkownika.");
                    return View(urlopViewModel);
                }

                urlopViewModel.PracownikId = userId;
                urlopViewModel.Status = Models.UrlopStatus.Oczekuje;

                _db.Urlopies.Add(urlopViewModel);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(urlopViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var urlop = await _db.Urlopies.FindAsync(id);

            if (urlop != null && urlop.Status == Models.UrlopStatus.Oczekuje)
            {
                urlop.Status = Models.UrlopStatus.Zaakceptowany;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var urlop = await _db.Urlopies.FindAsync(id);

            if (urlop != null && urlop.Status == Models.UrlopStatus.Oczekuje)
            {
                urlop.Status = Models.UrlopStatus.Odrzucony;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
