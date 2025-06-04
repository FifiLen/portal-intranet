// Controllers/AuthController.cs
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Intranet.Models;


namespace Intranet.Controllers
{
    public class AuthController : Controller
    {
        private readonly IntranetContext _db;
        public AuthController(IntranetContext db) => _db = db;

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(vm);

            // dopasuj nazwę właściwości do swojego modelu, np. HasloHash
            var user = await _db.Pracownicies
                .SingleOrDefaultAsync(u =>
                    u.Email == vm.Email &&
                    u.HasloHash == vm.Password
                );

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Nieprawidłowy email lub hasło.");
                return View(vm);
            }

            // budujemy claims z dodatkowymi informacjami
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,           user.Email),
                new Claim(ClaimTypes.GivenName,      $"{user.Imie} {user.Nazwisko}"),
                new Claim(ClaimTypes.Role,           user.Rola)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // logujemy i ustawiamy ciasteczko
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                }
            );

            // przekierowanie na stronę, z której przyszedł
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl!);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }

    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
