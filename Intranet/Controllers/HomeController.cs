using Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;

namespace Intranet.Controllers
{
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

            viewModel.OstatnieZamowienia = await _dbContext.Zamowienia
                .OrderByDescending(z => z.DataZlozenia)
                .Take(5)
                .ToListAsync();


            decimal dzisiejszaSprzedazDecimal = await _dbContext.Zamowienia
                .Where(z => z.DataZlozenia.Date == today &&
                             (z.Status == StatusZamowienia.Zrealizowane || z.Status == StatusZamowienia.Wyslane))
                .SumAsync(z => z.LacznaWartosc);
            viewModel.DzisiejszaSprzedaz = dzisiejszaSprzedazDecimal.ToString("C", new CultureInfo("pl-PL"));

            viewModel.ZamowieniaDoRealizacji = await _dbContext.Zamowienia.CountAsync(z =>
                z.Status == StatusZamowienia.Nowe ||
                z.Status == StatusZamowienia.PrzyjeteDoRealizacji ||
                z.Status == StatusZamowienia.WRealizacji);

            viewModel.ProduktyNaWyczerpaniu = await _dbContext.Produkty
                                                    .CountAsync(p => p.StanMagazynowy < 3);

            viewModel.DzisiejsiKlienci = await _dbContext.Zamowienia
                .Where(z => z.DataZlozenia.Date == today)
                .Select(z => z.EmailZamawiajacego)
                .Distinct()
                .CountAsync();

            var startDateChart = today.AddDays(-6);
            var salesData = new SalesChartData();

            var dailySales = await _dbContext.Zamowienia
                .Where(z => z.DataZlozenia.Date >= startDateChart && z.DataZlozenia.Date <= today &&
                             z.Status != StatusZamowienia.Anulowane)
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
                                        .Take(4)
                                        .ToListAsync();

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int? currentUserId = null;
            if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out var parsedUserId))
            {
                currentUserId = parsedUserId;
            }

            viewModel.Ogloszenia = await _dbContext.Ogloszenia
                                            .OrderByDescending(o => o.DataPublikacji)
                                            .Take(4)
                                            .ToListAsync();

            if (currentUserId.HasValue)
            {
                viewModel.MojeZadania = await _dbContext.Zadania
                                            .Where(z => z.PracownikId == currentUserId.Value && !z.CzyWykonane)
                                            .OrderBy(z => z.TerminWykonania ?? DateTime.MaxValue)
                                            .Take(5)
                                            .ToListAsync();
            }

            viewModel.NadchodzaceWydarzenia = await _dbContext.Wydarzenia
                                        .Where(w => w.DataRozpoczecia >= today)
                                        .OrderBy(w => w.DataRozpoczecia)
                                        .Take(3)
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
