using Microsoft.AspNetCore.Mvc;
using FashionStore.Models;
using Portal.Services;

namespace FashionStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;

        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Women()
        {
            var products = await _productService.GetByCategoryAsync("Women");
            return View(products);
        }

        public async Task<IActionResult> Men()
        {
            var products = await _productService.GetByCategoryAsync("Men");
            return View(products);
        }

        public async Task<IActionResult> Kids()
        {
            var products = await _productService.GetByCategoryAsync("Kids");
            return View(products);
        }

        public async Task<IActionResult> Accessories()
        {
            var products = await _productService.GetByCategoryAsync("Accessories");
            return View(products);
        }
    }
}
