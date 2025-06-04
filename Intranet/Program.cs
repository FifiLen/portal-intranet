using Intranet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// DbContext i auth jak dotychczas…
builder.Services.AddDbContext<IntranetContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("IntranetDb"))
);

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie(o =>
   {
       o.LoginPath = "/Auth/Login";
       o.ExpireTimeSpan = TimeSpan.FromHours(1);
   });

// **Tylko MVC** — nie Razor Pages
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();    // ← usunięte

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// **Mapujemy wyłącznie kontrolery MVC**
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

//app.MapRazorPages();  // ← usunięte

app.Run();
