using Microsoft.AspNetCore.Mvc;
using FashionStore.Models;
using System.Collections.Generic;

namespace FashionStore.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            // Przykładowe dane koszyka - w rzeczywistej aplikacji byłyby pobierane z sesji lub bazy danych
            var cartItems = new List<CartItemModel>
            {
                new CartItemModel {
                    Id = 1,
                    Name = "Oversized Blazer",
                    Price = 599.00m,
                    Quantity = 1,
                    ImageUrl = "/images/product-1.jpg",
                    Size = "M",
                    Color = "Czarny"
                },
                new CartItemModel {
                    Id = 2,
                    Name = "Minimalist Shirt",
                    Price = 299.00m,
                    Quantity = 2,
                    ImageUrl = "/images/product-2.jpg",
                    Size = "L",
                    Color = "Biały"
                },
                new CartItemModel {
                    Id = 3,
                    Name = "Leather Boots",
                    Price = 799.00m,
                    Quantity = 1,
                    ImageUrl = "/images/place-holder.jpg",
                    Size = "42",
                    Color = "Brązowy"
                }
            };

            // Przekazanie danych do widoku
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            // Tutaj kod do aktualizacji ilości produktu w koszyku
            // W rzeczywistej aplikacji aktualizowałby dane w sesji lub bazie danych

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult RemoveItem(int id)
        {
            // Tutaj kod do usunięcia produktu z koszyka
            // W rzeczywistej aplikacji usuwałby produkt z sesji lub bazy danych

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            // Tutaj kod do wyczyszczenia koszyka
            // W rzeczywistej aplikacji czyściłby koszyk w sesji lub bazie danych

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult ApplyDiscount(string code)
        {
            // Tutaj kod do weryfikacji i zastosowania kodu rabatowego
            // W rzeczywistej aplikacji sprawdzałby kod w bazie danych i stosował odpowiedni rabat

            decimal discount = 0;

            // Przykładowa logika dla kodu rabatowego "WELCOME10"
            if (code == "WELCOME10")
            {
                discount = 50.00m;
                TempData["Discount"] = discount;
                return Json(new { success = true, discount = discount });
            }

            return Json(new { success = false, message = "Nieprawidłowy kod rabatowy" });
        }
    }
}
