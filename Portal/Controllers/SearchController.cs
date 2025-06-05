using Microsoft.AspNetCore.Mvc;
using Portal.Services;

namespace Portal.Controllers;

public class SearchController : Controller
{
    private readonly IProductService _products;
    public SearchController(IProductService products) => _products = products;

    public async Task<IActionResult> Index(string q)
    {
        var results = await _products.SearchAsync(q ?? "");
        ViewData["Query"] = q ?? string.Empty;
        return View(results);
    }
}
