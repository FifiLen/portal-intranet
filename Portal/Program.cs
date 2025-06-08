using System.Reflection;
using Intranet.Models;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Portal.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IntranetContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("IntranetDb")));

builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddScoped<PortalTextService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();

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

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
