using Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Intranet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OgloszeniaController : Controller
    {
        private readonly IntranetContext _context;

        public OgloszeniaController(IntranetContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var model = new Ogloszenie
            {
                DataPublikacji = DateTime.Today
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Tytul,Tresc,DataPublikacji,Dzial,Typ,CzyWazne")] Ogloszenie ogloszenie)
        {

            if (ModelState.IsValid)
            {
                _context.Add(ogloszenie);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Ogłoszenie zostało pomyślnie dodane.";
                return RedirectToAction("Index", "Home");
            }
            return View(ogloszenie);
        }

    }
}
