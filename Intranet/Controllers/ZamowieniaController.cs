using Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly IntranetContext _context;

        public ZamowieniaController(IntranetContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var zamowienia = await _context.Zamowienia
                                        .Include(z => z.PozycjeZamowien)
                                            .ThenInclude(pz => pz.Produkt)
                                        .OrderByDescending(z => z.DataZlozenia)
                                        .ToListAsync();
            return View(zamowienia);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia
                .Include(z => z.PozycjeZamowien)
                    .ThenInclude(pz => pz.Produkt)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienia.FindAsync(id);

            if (zamowienie == null)
            {
                return NotFound();
            }
            return View(zamowienie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,DataZlozenia,ImieZamawiajacego,NazwiskoZamawiajacego,EmailZamawiajacego,LacznaWartosc,Status")] Zamowienie zamowienie)
        {
            if (id != zamowienie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Zamówienie zostało zaktualizowane.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Wystąpił błąd współbieżności. Spróbuj ponownie.");
                        return View(zamowienie);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(zamowienie);
        }

        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienia.Any(e => e.Id == id);
        }
    }
}
