using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;              // do sesji
using FashionStore.Models;                    // CartPageViewModel, CheckoutFormModel
using Intranet.Models;                        // Zamowienie, PozycjaZamowienia, StatusZamowienia, IntranetContext
using Portal.Services;                        // ICartService, IProductService

namespace FashionStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService    _cartService;
        private readonly IntranetContext _context;
        private readonly IProductService _productService;

        public CartController(
            ICartService cartService,
            IntranetContext context,
            IProductService productService)
        {
            _cartService    = cartService;
            _context        = context;
            _productService = productService;
        }

        // ────────────── KOSZYK ──────────────
        public async Task<IActionResult> Index()
        {
            var cartItems   = await _cartService.GetItemsAsync();
            var recommended = await _productService.GetRandomAsync(4);

            var vm = new CartPageViewModel
            {
                Items       = cartItems,
                Recommended = recommended
            };

            return View(vm);
        }

        // ────────────── OPERACJE AJAX ──────────────
        [HttpPost]
        public async Task<IActionResult> Add(int productId, int quantity = 1)
        {
            await _cartService.AddItemAsync(productId, quantity);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            await _cartService.UpdateQuantityAsync(id, quantity);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int id)
        {
            await _cartService.RemoveItemAsync(id);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            await _cartService.ClearAsync();
            return Json(new { success = true });
        }

        // ────────────── CHECKOUT ──────────────
        public IActionResult Checkout()
        {
            var model = new CheckoutFormModel();

            // jeśli użytkownik zalogowany (Id w sesji) – wypełnij danymi
            var uid = HttpContext.Session.GetInt32("UserId");
            if (uid != null)
            {
                var user = _context.Uzytkownicy.Find(uid.Value);
                if (user != null)
                {
                    model.FirstName = user.Imie;
                    model.LastName  = user.Nazwisko;
                    model.Email     = user.Email;
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutFormModel model)
        {
            var items = await _cartService.GetItemsAsync();

            if (!items.Any())
                ModelState.AddModelError(string.Empty, "Koszyk jest pusty");

            if (!ModelState.IsValid)
                return View(model);

            var order = new Zamowienie
            {
                DataZlozenia          = DateTime.UtcNow,
                ImieZamawiajacego     = model.FirstName,
                NazwiskoZamawiajacego = model.LastName,
                EmailZamawiajacego    = model.Email,
                UzytkownikId          = HttpContext.Session.GetInt32("UserId"),
                Status                = StatusZamowienia.Nowe,
                PozycjeZamowien       = items.Select(i => new PozycjaZamowienia
                {
                    ProduktId       = i.Id,
                    Ilosc           = i.Quantity,
                    CenaJednostkowa = i.Price
                }).ToList()
            };

            order.LacznaWartosc = order.PozycjeZamowien
                                      .Sum(p => p.Ilosc * p.CenaJednostkowa);

            _context.Zamowienia.Add(order);
            await _context.SaveChangesAsync();
            await _cartService.ClearAsync();

            return RedirectToAction(nameof(Success), new { id = order.Id });
        }

        // ────────────── ZAMÓWIENIE ZŁOŻONE ──────────────
        public async Task<IActionResult> Success(int id)
        {
            var order = await _context.Zamowienia.FindAsync(id);
            if (order == null) return RedirectToAction(nameof(Index));

            return View(order);
        }
    }
}
