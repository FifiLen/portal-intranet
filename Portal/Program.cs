using System.Reflection;
using Intranet.Models;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Portal.Services;

var builder = WebApplication.CreateBuilder(args);

// ────────────── SERWISY ──────────────
builder.Services.AddDbContext<IntranetContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("IntranetDb")));

builder.Services.AddMemoryCache();

builder.Services.AddScoped<PortalTextService>();
builder.Services.AddScoped<IProductService, ProductService>();

// nowości z gałęzi Codex ↓
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddScoped<ICartService, CartService>();

// ────────────── MVC (bez kontrolerów Intranet) ──────────────
builder.Services.AddControllersWithViews()
    .ConfigureApplicationPartManager(apm =>
    {
        var intranetParts = apm.ApplicationParts
            .OfType<AssemblyPart>()
            .Where(p => p.Assembly.GetName().Name == "Intranet")
            .ToList();

        foreach (var part in intranetParts)
            apm.ApplicationParts.Remove(part);
    });

var app = builder.Build();

// ────────────── PIPELINE ──────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();       // (Codex) sesje muszą być przed autoryzacją
app.UseAuthorization(); // zostawiamy, jeśli kiedyś dodasz autoryzację

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
