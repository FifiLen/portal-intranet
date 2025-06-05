using Intranet.Models;
using Microsoft.EntityFrameworkCore;
using Portal.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Intranet.Models.IntranetContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("IntranetDb")));
builder.Services.AddMemoryCache();
builder.Services.AddScoped<Portal.Services.PortalTextService>();
builder.Services.AddScoped<Portal.Services.IProductService, Portal.Services.ProductService>();

// Add services to the container.
builder.Services.AddControllersWithViews(); // ZMIANA: Rejestracja usług dla MVC

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // ZMIANA (zalecana): Wskazanie konkretnej akcji kontrolera dla błędu
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage(); // Przydatne w trybie deweloperskim
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization(); // Pozostaje, jeśli używasz autoryzacji

// ZMIANA: Mapowanie domyślnej trasy dla kontrolerów MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
