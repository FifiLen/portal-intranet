using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Portal.Models; // Poprawna przestrzeń nazw dla modeli

namespace Portal.Controllers // Poprawna przestrzeń nazw dla kontrolera
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Inne akcje, które masz, np. Kontakt, Koszyk, Sklep
        // public IActionResult Kontakt() { return View(); }
        // public IActionResult Koszyk() { return View(); }
        // public IActionResult Sklep() { return View(); }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Tutaj ErrorViewModel jest już poprawnie używany z przestrzeni nazw Portal.Models
            // dzięki dyrektywie 'using Portal.Models;' na górze pliku.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
