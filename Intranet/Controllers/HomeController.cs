using Intranet.Models; // Dla DashboardViewModel, Zamowienie, Produkt, StatusZamowienia, IntranetContext, ErrorViewModel
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Dla Include, OrderByDescending, ToListAsync, CountAsync, SumAsync, Take
using System.Diagnostics; // Dla ErrorViewModel
using System.Linq;         // Dla OrderByDescending, Take, Count, GroupBy, Select, Distinct
using System.Threading.Tasks;  // Dla async/await
using Microsoft.Extensions.Logging; // Dla ILogger
using System; // Dla DateTime
using System.Collections.Generic; // Dla List<>
using System.Globalization;
using System.Security.Claims; // Dla CultureInfo
// using Microsoft.AspNetCore.Authorization; // Odkomentuj, jeśli dashboard wymaga autoryzacji

namespace Intranet.Controllers
{
    // [Authorize] // Odkomentuj, jeśli dashboard wymaga autoryzacji
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IntranetContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IntranetContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardViewModel();
            var today = DateTime.Today;
            // var yesterday = today.AddDays(-1); // Możesz potrzebować do porównań "vs wczoraj"

            // 1. Ostatnie zamówienia
            viewModel.OstatnieZamowienia = await _dbContext.Zamowienia
                .OrderByDescending(z => z.DataZlozenia)
                .Take(5)
                .ToListAsync();

            // 2. Obliczanie statystyk

            // Dzisiejsza sprzedaż (zamówienia Zrealizowane lub Wyslane z dzisiaj)
            decimal dzisiejszaSprzedazDecimal = await _dbContext.Zamowienia
                .Where(z => z.DataZlozenia.Date == today &&
                             (z.Status == StatusZamowienia.Zrealizowane || z.Status == StatusZamowienia.Wyslane))
                .SumAsync(z => z.LacznaWartosc);
            viewModel.DzisiejszaSprzedaz = dzisiejszaSprzedazDecimal.ToString("C", new CultureInfo("pl-PL"));

            // Zamówienia do realizacji
            viewModel.ZamowieniaDoRealizacji = await _dbContext.Zamowienia.CountAsync(z =>
                z.Status == StatusZamowienia.Nowe ||
                z.Status == StatusZamowienia.PrzyjeteDoRealizacji ||
                z.Status == StatusZamowienia.WRealizacji);

            // Produkty na wyczerpaniu (np. stan magazynowy < 10)
            viewModel.ProduktyNaWyczerpaniu = await _dbContext.Produkty
                                                    .CountAsync(p => p.StanMagazynowy < 3);

            // Dzisiejsi klienci (unikalni klienci z zamówień złożonych dzisiaj)
            viewModel.DzisiejsiKlienci = await _dbContext.Zamowienia
                .Where(z => z.DataZlozenia.Date == today)
                .Select(z => z.EmailZamawiajacego)
                .Distinct()
                .CountAsync();

            // Wykres sprzedaży tygodniowej
            var startDateChart = today.AddDays(-6); // Ostatnie 7 dni
            var salesData = new SalesChartData();

            var dailySales = await _dbContext.Zamowienia
                .Where(z => z.DataZlozenia.Date >= startDateChart && z.DataZlozenia.Date <= today &&
                             z.Status != StatusZamowienia.Anulowane) // Sprzedaż to wszystkie nieanulowane zamówienia
                .GroupBy(z => z.DataZlozenia.Date)
                .Select(g => new { Date = g.Key, TotalSales = g.Sum(z => z.LacznaWartosc) })
                .OrderBy(x => x.Date)
                .ToListAsync();

            for (int i = 0; i < 7; i++)
            {
                var currentDate = startDateChart.AddDays(i);
                salesData.Labels.Add(currentDate.ToString("dd.MM"));

                var saleForDay = dailySales.FirstOrDefault(s => s.Date == currentDate);
                salesData.Values.Add(saleForDay?.TotalSales ?? 0m);
            }
            viewModel.SprzedazTygodniowaChartData = salesData;

            viewModel.Ogloszenia = await _dbContext.Ogloszenia
                                        .OrderByDescending(o => o.DataPublikacji)
                                        .Take(4) // Możesz dostosować liczbę wyświetlanych ogłoszeń
                                        .ToListAsync();

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int? currentUserId = null;
            if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out var parsedUserId))
            {
                currentUserId = parsedUserId;
            }

            // ... (kod pobierania danych dla statystyk, ostatnich zamówień, wykresu, ogłoszeń) ...
            viewModel.Ogloszenia = await _dbContext.Ogloszenia
                                            .OrderByDescending(o => o.DataPublikacji)
                                            .Take(4)
                                            .ToListAsync();

            // Pobierz zadania dla zalogowanego użytkownika (jeśli jest zalogowany)
            if (currentUserId.HasValue)
            {
                viewModel.MojeZadania = await _dbContext.Zadania
                                            .Where(z => z.PracownikId == currentUserId.Value && !z.CzyWykonane) // Tylko niewykonane zadania
                                            .OrderBy(z => z.TerminWykonania ?? DateTime.MaxValue) // Sortuj po terminie (null na końcu)
                                            .Take(5) // Pokaż np. 5 najbliższych zadań
                                            .ToListAsync();
            }

            viewModel.NadchodzaceWydarzenia = await _dbContext.Wydarzenia
                                        .Where(w => w.DataRozpoczecia >= today) // Wydarzenia od dzisiaj włącznie
                                        .OrderBy(w => w.DataRozpoczecia)
                                        .Take(3) // Możesz dostosować liczbę wyświetlanych wydarzeń
                                        .ToListAsync();

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
