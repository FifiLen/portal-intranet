using Microsoft.AspNetCore.Mvc;
using FashionStore.Models;
using System.Collections.Generic;

namespace FashionStore.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Women()
        {
            // Przykładowe dane produktów dla kategorii kobiet
            var products = new List<ProductModel>
            {
                new ProductModel {
                    Id = 1,
                    Name = "Oversized Blazer",
                    Price = 599.00m,
                    OldPrice = 799.00m,
                    Discount = 25,
                    IsNew = false,
                    ImageUrl = "/images/product-1.jpg",
                    Tags = new List<string> { "blazer", "oversize", "czarny" },
                    Colors = new List<string> { "czarny", "beżowy", "szary" },
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" },
                    Featured = true
                },
                new ProductModel {
                    Id = 2,
                    Name = "Minimalist Shirt",
                    Price = 299.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/product-2.jpg",
                    Tags = new List<string> { "koszula", "minimalizm", "biały" },
                    Colors = new List<string> { "biały", "czarny", "niebieski" },
                    Sizes = new List<string> { "XS", "S", "M", "L" },
                    Featured = false
                },
                new ProductModel {
                    Id = 3,
                    Name = "Wool Blend Coat",
                    Price = 899.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/product-3.jpg",
                    Tags = new List<string> { "płaszcz", "wełna", "beżowy" },
                    Colors = new List<string> { "beżowy", "czarny", "szary" },
                    Sizes = new List<string> { "S", "M", "L", "XL" },
                    Featured = true
                },
                new ProductModel {
                    Id = 4,
                    Name = "Structured Bag",
                    Price = 459.00m,
                    OldPrice = 599.00m,
                    Discount = 23,
                    IsNew = false,
                    ImageUrl = "/images/product-4.jpg",
                    Tags = new List<string> { "torebka", "skóra", "czarny" },
                    Colors = new List<string> { "czarny", "brązowy", "czerwony" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 5,
                    Name = "Silk Blouse",
                    Price = 399.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "bluzka", "jedwab", "kremowy" },
                    Colors = new List<string> { "kremowy", "różowy", "czarny" },
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" },
                    Featured = false
                },
                new ProductModel {
                    Id = 6,
                    Name = "High Waist Jeans",
                    Price = 349.00m,
                    OldPrice = 449.00m,
                    Discount = 22,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "jeansy", "high waist", "niebieski" },
                    Colors = new List<string> { "niebieski", "czarny" },
                    Sizes = new List<string> { "34", "36", "38", "40", "42" },
                    Featured = true
                },
                new ProductModel {
                    Id = 7,
                    Name = "Cashmere Sweater",
                    Price = 699.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "sweter", "kaszmir", "szary" },
                    Colors = new List<string> { "szary", "beżowy", "czarny", "burgundowy" },
                    Sizes = new List<string> { "S", "M", "L" },
                    Featured = false
                },
                new ProductModel {
                    Id = 8,
                    Name = "Pleated Midi Skirt",
                    Price = 499.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "spódnica", "plisowana", "midi", "czarny" },
                    Colors = new List<string> { "czarny", "granatowy", "beżowy" },
                    Sizes = new List<string> { "XS", "S", "M", "L" },
                    Featured = true
                },
                new ProductModel {
                    Id = 9,
                    Name = "Leather Jacket",
                    Price = 1299.00m,
                    OldPrice = 1599.00m,
                    Discount = 19,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "kurtka", "skóra", "czarny" },
                    Colors = new List<string> { "czarny", "brązowy" },
                    Sizes = new List<string> { "XS", "S", "M", "L", "XL" },
                    Featured = false
                },
                new ProductModel {
                    Id = 10,
                    Name = "Linen Dress",
                    Price = 549.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "sukienka", "len", "biały" },
                    Colors = new List<string> { "biały", "beżowy", "niebieski" },
                    Sizes = new List<string> { "XS", "S", "M", "L" },
                    Featured = true
                },
                new ProductModel {
                    Id = 11,
                    Name = "Wool Beret",
                    Price = 199.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "beret", "wełna", "czerwony" },
                    Colors = new List<string> { "czerwony", "czarny", "beżowy", "granatowy" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 12,
                    Name = "Satin Slip Dress",
                    Price = 599.00m,
                    OldPrice = 799.00m,
                    Discount = 25,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "sukienka", "satyna", "czarny" },
                    Colors = new List<string> { "czarny", "burgundowy", "szampański" },
                    Sizes = new List<string> { "XS", "S", "M", "L" },
                    Featured = true
                }
            };

            // Przekazanie danych do widoku
            return View(products);
        }

        public IActionResult Men()
        {
            // Przykładowe dane produktów dla kategorii mężczyzn
            var products = new List<ProductModel>
            {
                new ProductModel {
                    Id = 101,
                    Name = "Minimalist Overcoat",
                    Price = 899.00m,
                    OldPrice = 1199.00m,
                    Discount = 25,
                    IsNew = false,
                    ImageUrl = "/images/men-product-1.jpg",
                    Tags = new List<string> { "płaszcz", "minimalizm", "czarny" },
                    Colors = new List<string> { "czarny", "granatowy", "szary" },
                    Sizes = new List<string> { "S", "M", "L", "XL", "XXL" },
                    Featured = true
                },
                new ProductModel {
                    Id = 102,
                    Name = "Structured Shirt",
                    Price = 349.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/men-product-2.jpg",
                    Tags = new List<string> { "koszula", "bawełna", "biały" },
                    Colors = new List<string> { "biały", "czarny", "błękitny" },
                    Sizes = new List<string> { "S", "M", "L", "XL" },
                    Featured = false
                },
                new ProductModel {
                    Id = 103,
                    Name = "Wool Sweater",
                    Price = 499.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/men-product-3.jpg",
                    Tags = new List<string> { "sweter", "wełna", "granatowy" },
                    Colors = new List<string> { "granatowy", "szary", "czarny" },
                    Sizes = new List<string> { "S", "M", "L", "XL", "XXL" },
                    Featured = true
                },
                new ProductModel {
                    Id = 104,
                    Name = "Leather Boots",
                    Price = 799.00m,
                    OldPrice = 999.00m,
                    Discount = 20,
                    IsNew = false,
                    ImageUrl = "/images/men-product-4.jpg",
                    Tags = new List<string> { "buty", "skóra", "brązowy" },
                    Colors = new List<string> { "brązowy", "czarny" },
                    Sizes = new List<string> { "40", "41", "42", "43", "44", "45" },
                    Featured = false
                },
                new ProductModel {
                    Id = 105,
                    Name = "Slim Fit Jeans",
                    Price = 399.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "jeansy", "slim fit", "niebieski" },
                    Colors = new List<string> { "niebieski", "czarny", "szary" },
                    Sizes = new List<string> { "30", "32", "34", "36", "38" },
                    Featured = false
                },
                new ProductModel {
                    Id = 106,
                    Name = "Bomber Jacket",
                    Price = 649.00m,
                    OldPrice = 799.00m,
                    Discount = 19,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "kurtka", "bomber", "zielony" },
                    Colors = new List<string> { "zielony", "czarny", "granatowy" },
                    Sizes = new List<string> { "S", "M", "L", "XL" },
                    Featured = true
                },
                new ProductModel {
                    Id = 107,
                    Name = "Merino Turtleneck",
                    Price = 449.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "golf", "merino", "czarny" },
                    Colors = new List<string> { "czarny", "szary", "granatowy", "bordowy" },
                    Sizes = new List<string> { "S", "M", "L", "XL" },
                    Featured = false
                },
                new ProductModel {
                    Id = 108,
                    Name = "Tailored Trousers",
                    Price = 499.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "spodnie", "eleganckie", "szary" },
                    Colors = new List<string> { "szary", "granatowy", "czarny" },
                    Sizes = new List<string> { "48", "50", "52", "54", "56" },
                    Featured = true
                },
                new ProductModel {
                    Id = 109,
                    Name = "Leather Wallet",
                    Price = 249.00m,
                    OldPrice = 299.00m,
                    Discount = 17,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "portfel", "skóra", "brązowy" },
                    Colors = new List<string> { "brązowy", "czarny" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 110,
                    Name = "Cashmere Scarf",
                    Price = 349.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "szalik", "kaszmir", "szary" },
                    Colors = new List<string> { "szary", "granatowy", "czarny", "bordowy" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 111,
                    Name = "Leather Belt",
                    Price = 199.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "pasek", "skóra", "brązowy" },
                    Colors = new List<string> { "brązowy", "czarny" },
                    Sizes = new List<string> { "90", "95", "100", "105", "110" },
                    Featured = false
                },
                new ProductModel {
                    Id = 112,
                    Name = "Wool Coat",
                    Price = 999.00m,
                    OldPrice = 1299.00m,
                    Discount = 23,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "płaszcz", "wełna", "granatowy" },
                    Colors = new List<string> { "granatowy", "czarny", "szary" },
                    Sizes = new List<string> { "S", "M", "L", "XL", "XXL" },
                    Featured = true
                }
            };

            // Przekazanie danych do widoku
            return View(products);
        }

        public IActionResult Kids()
        {
            // Przykładowe dane produktów dla kategorii dzieci
            var products = new List<ProductModel>
            {
                new ProductModel {
                    Id = 201,
                    Name = "Bluza z kapturem",
                    Price = 129.00m,
                    OldPrice = 159.00m,
                    Discount = 19,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "bluza", "kaptur", "bawełna", "niebieski" },
                    Colors = new List<string> { "niebieski", "czerwony", "szary" },
                    Sizes = new List<string> { "92", "98", "104", "110", "116", "122", "128" },
                    Featured = true
                },
                new ProductModel {
                    Id = 202,
                    Name = "Spodnie dresowe",
                    Price = 89.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "spodnie", "dres", "bawełna", "szary" },
                    Colors = new List<string> { "szary", "granatowy", "czarny" },
                    Sizes = new List<string> { "92", "98", "104", "110", "116", "122", "128" },
                    Featured = false
                },
                new ProductModel {
                    Id = 203,
                    Name = "Kurtka zimowa",
                    Price = 249.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "kurtka", "zima", "czerwony" },
                    Colors = new List<string> { "czerwony", "granatowy", "różowy" },
                    Sizes = new List<string> { "104", "110", "116", "122", "128", "134", "140" },
                    Featured = true
                },
                new ProductModel {
                    Id = 204,
                    Name = "T-shirt z nadrukiem",
                    Price = 49.00m,
                    OldPrice = 69.00m,
                    Discount = 29,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "t-shirt", "nadruk", "bawełna", "biały" },
                    Colors = new List<string> { "biały", "żółty", "zielony" },
                    Sizes = new List<string> { "92", "98", "104", "110", "116", "122", "128" },
                    Featured = false
                },
                new ProductModel {
                    Id = 205,
                    Name = "Sukienka w kropki",
                    Price = 119.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "sukienka", "kropki", "różowy" },
                    Colors = new List<string> { "różowy", "niebieski" },
                    Sizes = new List<string> { "92", "98", "104", "110", "116", "122", "128" },
                    Featured = false
                },
                new ProductModel {
                    Id = 206,
                    Name = "Jeansy z naszywkami",
                    Price = 129.00m,
                    OldPrice = 159.00m,
                    Discount = 19,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "jeansy", "naszywki", "niebieski" },
                    Colors = new List<string> { "niebieski" },
                    Sizes = new List<string> { "104", "110", "116", "122", "128", "134", "140" },
                    Featured = true
                },
                new ProductModel {
                    Id = 207,
                    Name = "Sweter z wełny",
                    Price = 149.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "sweter", "wełna", "beżowy" },
                    Colors = new List<string> { "beżowy", "szary", "granatowy" },
                    Sizes = new List<string> { "104", "110", "116", "122", "128", "134", "140" },
                    Featured = false
                },
                new ProductModel {
                    Id = 208,
                    Name = "Czapka zimowa",
                    Price = 59.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "czapka", "zima", "czerwony" },
                    Colors = new List<string> { "czerwony", "granatowy", "różowy", "szary" },
                    Sizes = new List<string> { "S", "M", "L" },
                    Featured = true
                },
                new ProductModel {
                    Id = 209,
                    Name = "Kalosze",
                    Price = 89.00m,
                    OldPrice = 119.00m,
                    Discount = 25,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "buty", "kalosze", "żółty" },
                    Colors = new List<string> { "żółty", "niebieski", "czerwony" },
                    Sizes = new List<string> { "22", "23", "24", "25", "26", "27", "28", "29", "30" },
                    Featured = false
                },
                new ProductModel {
                    Id = 210,
                    Name = "Piżama bawełniana",
                    Price = 79.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "piżama", "bawełna", "niebieski" },
                    Colors = new List<string> { "niebieski", "różowy", "zielony" },
                    Sizes = new List<string> { "92", "98", "104", "110", "116", "122", "128" },
                    Featured = false
                },
                new ProductModel {
                    Id = 211,
                    Name = "Szalik i rękawiczki",
                    Price = 69.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "szalik", "rękawiczki", "zestaw", "czerwony" },
                    Colors = new List<string> { "czerwony", "granatowy", "różowy" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 212,
                    Name = "Kombinezon zimowy",
                    Price = 299.00m,
                    OldPrice = 349.00m,
                    Discount = 14,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "kombinezon", "zima", "granatowy" },
                    Colors = new List<string> { "granatowy", "czerwony", "różowy" },
                    Sizes = new List<string> { "92", "98", "104", "110", "116", "122", "128" },
                    Featured = true
                }
            };

            // Przekazanie danych do widoku
            return View(products);
        }

        public IActionResult Accessories()
        {
            // Przykładowe dane produktów dla kategorii akcesoriów
            var products = new List<ProductModel>
            {
                new ProductModel {
                    Id = 301,
                    Name = "Skórzana torebka",
                    Price = 499.00m,
                    OldPrice = 599.00m,
                    Discount = 17,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "torebka", "skóra", "czarny" },
                    Colors = new List<string> { "czarny", "brązowy", "beżowy" },
                    Sizes = new List<string> { "One Size" },
                    Featured = true
                },
                new ProductModel {
                    Id = 302,
                    Name = "Złoty naszyjnik",
                    Price = 349.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "naszyjnik", "złoty", "biżuteria" },
                    Colors = new List<string> { "złoty" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 303,
                    Name = "Skórzany pasek",
                    Price = 199.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "pasek", "skóra", "brązowy" },
                    Colors = new List<string> { "brązowy", "czarny" },
                    Sizes = new List<string> { "85", "90", "95", "100", "105" },
                    Featured = true
                },
                new ProductModel {
                    Id = 304,
                    Name = "Jedwabny szalik",
                    Price = 259.00m,
                    OldPrice = 299.00m,
                    Discount = 13,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "szalik", "jedwab", "czerwony" },
                    Colors = new List<string> { "czerwony", "granatowy", "zielony" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 305,
                    Name = "Srebrne kolczyki",
                    Price = 199.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "kolczyki", "srebro", "biżuteria" },
                    Colors = new List<string> { "srebrny" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 306,
                    Name = "Wełniany beret",
                    Price = 129.00m,
                    OldPrice = 159.00m,
                    Discount = 19,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "beret", "wełna", "czarny" },
                    Colors = new List<string> { "czarny", "czerwony", "beżowy" },
                    Sizes = new List<string> { "One Size" },
                    Featured = true
                },
                new ProductModel {
                    Id = 307,
                    Name = "Skórzane rękawiczki",
                    Price = 179.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "rękawiczki", "skóra", "czarny" },
                    Colors = new List<string> { "czarny", "brązowy" },
                    Sizes = new List<string> { "S", "M", "L" },
                    Featured = false
                },
                new ProductModel {
                    Id = 308,
                    Name = "Zegarek minimalistyczny",
                    Price = 599.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "zegarek", "minimalizm", "srebrny" },
                    Colors = new List<string> { "srebrny", "złoty", "czarny" },
                    Sizes = new List<string> { "One Size" },
                    Featured = true
                },
                new ProductModel {
                    Id = 309,
                    Name = "Skórzany portfel",
                    Price = 249.00m,
                    OldPrice = 299.00m,
                    Discount = 17,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "portfel", "skóra", "brązowy" },
                    Colors = new List<string> { "brązowy", "czarny", "granatowy" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 310,
                    Name = "Okulary przeciwsłoneczne",
                    Price = 299.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = true,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "okulary", "czarny" },
                    Colors = new List<string> { "czarny", "brązowy", "złoty" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 311,
                    Name = "Jedwabna apaszka",
                    Price = 179.00m,
                    OldPrice = null,
                    Discount = null,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "apaszka", "jedwab", "wzór" },
                    Colors = new List<string> { "wielokolorowy", "niebieski", "czerwony" },
                    Sizes = new List<string> { "One Size" },
                    Featured = false
                },
                new ProductModel {
                    Id = 312,
                    Name = "Skórzana aktówka",
                    Price = 799.00m,
                    OldPrice = 999.00m,
                    Discount = 20,
                    IsNew = false,
                    ImageUrl = "/images/place-holder.jpg",
                    Tags = new List<string> { "aktówka", "skóra", "czarny" },
                    Colors = new List<string> { "czarny", "brązowy" },
                    Sizes = new List<string> { "One Size" },
                    Featured = true
                }
            };

            // Przekazanie danych do widoku
            return View(products);
        }
    }
}
