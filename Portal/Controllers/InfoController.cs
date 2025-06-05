using Microsoft.AspNetCore.Mvc;

namespace FashionStore.Controllers;

public class InfoController : Controller
{
    public IActionResult About() => View();
    public IActionResult Jobs() => View();
    public IActionResult Terms() => View();
    public IActionResult Privacy() => View();
    public IActionResult Contact() => View();
    public IActionResult Shipping() => View();
    public IActionResult Returns() => View();
    public IActionResult Faq() => View();
}
