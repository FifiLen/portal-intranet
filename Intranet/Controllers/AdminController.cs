using Intranet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks; // Dodaj ten using, jeśli go brakuje

namespace Intranet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IntranetContext _db;
        // W konstruktorze typ parametru 'db' jest poprawny (IntranetContext)
        public AdminController(IntranetContext db) => _db = db;

        // GET: /Admin
        public async Task<IActionResult> Index()
        {
            // ZMIANA: _db.Pracownicy -> _db.Pracownicies
            // ZMIANA: Typ zmiennej 'users' będzie teraz List<Pracownicies>
            var users = await _db.Pracownicies.ToListAsync();
            return View(users); // Widok Index.cshtml dla Admin musi oczekiwać @model IEnumerable<Intranet.Models.Pracownicies>
        }

        // GET: /Admin/Create
        public IActionResult Create() => View(); // Widok Create.cshtml dla Admin musi oczekiwać @model Intranet.Models.Pracownicies

        // POST: /Admin/Create
        [HttpPost, ValidateAntiForgeryToken]
        // ZMIANA: Typ parametru Pracownicy -> Pracownicies
        public async Task<IActionResult> Create(Pracownicy user)
        {
            if (!ModelState.IsValid) return View(user);
            // ZMIANA: _db.Pracownicy -> _db.Pracownicies
            _db.Pracownicies.Add(user);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // ZMIANA: _db.Pracownicy -> _db.Pracownicies
            // ZMIANA: Typ zmiennej 'user' będzie teraz Pracownicies?
            var user = await _db.Pracownicies.FindAsync(id);
            if (user == null) return NotFound();
            return View(user); // Widok Edit.cshtml dla Admin musi oczekiwać @model Intranet.Models.Pracownicies
        }

        // POST: /Admin/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        // ZMIANA: Typ parametru Pracownicy -> Pracownicies
        public async Task<IActionResult> Edit(int id, Pracownicy user)
        {
            if (id != user.Id) return BadRequest();
            if (!ModelState.IsValid) return View(user);

            _db.Entry(user).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            // ZMIANA: _db.Pracownicy -> _db.Pracownicies
            // ZMIANA: Typ zmiennej 'user' będzie teraz Pracownicies?
            var user = await _db.Pracownicies.FindAsync(id);
            if (user == null) return NotFound();
            return View(user); // Widok Delete.cshtml dla Admin musi oczekiwać @model Intranet.Models.Pracownicies
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // ZMIANA: _db.Pracownicy -> _db.Pracownicies
            var user = await _db.Pracownicies.FindAsync(id);
            if (user != null)
            {
                // ZMIANA: _db.Pracownicy -> _db.Pracownicies
                _db.Pracownicies.Remove(user);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
