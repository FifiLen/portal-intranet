using Microsoft.AspNetCore.Mvc;
using Portal.Services;

namespace Portal.Controllers;

public class SearchController : Controller
{
    private readonly IProductService _products;
    public SearchController(IProductService products) => _products = products;

    public async Task<IActionResult> Index(string? q, string? category, decimal? minPrice, decimal? maxPrice)
    {
        var results = await _products.SearchAsync(q, category, minPrice, maxPrice);
        ViewData["Query"] = q ?? string.Empty;
        return View(results);
    }
}
