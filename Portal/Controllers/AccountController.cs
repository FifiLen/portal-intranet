using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Intranet.Models;

namespace Portal.Controllers;

public class AccountController : Controller
{
    private readonly IntranetContext _db;
    private const string SessionKey = "UserId";

    public AccountController(IntranetContext db) => _db = db;

    private int? CurrentUserId => HttpContext.Session.GetInt32(SessionKey);

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _db.Uzytkownicy.FirstOrDefaultAsync(u => u.Email == email && u.HasloHash == password);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Nieprawidłowe dane logowania");
            return View();
        }
        HttpContext.Session.SetInt32(SessionKey, user.Id);
        return RedirectToAction("Profile");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove(SessionKey);
        return RedirectToAction("Login");
    }

    public async Task<IActionResult> Profile()
    {
        if (CurrentUserId == null) return RedirectToAction("Login");
        var user = await _db.Uzytkownicy.FindAsync(CurrentUserId.Value);
        if (user == null) return RedirectToAction("Login");
        var orders = await _db.Zamowienia.Where(z => z.UzytkownikId == user.Id).ToListAsync();
        ViewData["Orders"] = orders;
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, string imie, string nazwisko, string email, string numerTelefonu)
    {
        var user = await _db.Uzytkownicy.FindAsync(id);
        if (user == null) return RedirectToAction("Profile");
        user.Imie = imie;
        user.Nazwisko = nazwisko;
        user.Email = email;
        user.NumerTelefonu = numerTelefonu;
        await _db.SaveChangesAsync();
        return RedirectToAction("Profile");
    }
}
