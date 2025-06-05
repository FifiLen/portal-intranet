using Intranet.Models;
using FashionStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Portal.Services;

public class ProductService : IProductService
{
    private readonly IntranetContext _context;

    public ProductService(IntranetContext context)
    {
        _context = context;
    }

    public async Task<List<ProductModel>> GetFeaturedAsync(int count = 4)
    {
        var products = await _context.Produkty
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .Take(count)
            .ToListAsync();

        return products.Select(p => new ProductModel
        {
            Id = p.Id,
            Name = p.Nazwa,
            Price = p.Cena,
            OldPrice = null,
            Discount = null,
            IsNew = false,
            ImageUrl = "/images/place-holder.jpg",
            Tags = new List<string>(),
            Colors = new List<string>(),
            Sizes = new List<string>(),
            Featured = false
        }).ToList();
    }

    public async Task<List<ProductModel>> GetByCategoryAsync(string category)
    {
        var products = await _context.Produkty
            .AsNoTracking()
            .Where(p => p.Kategoria == category)
            .ToListAsync();

        return products.Select(p => new ProductModel
        {
            Id = p.Id,
            Name = p.Nazwa,
            Price = p.Cena,
            OldPrice = null,
            Discount = null,
            IsNew = false,
            ImageUrl = "/images/place-holder.jpg",
            Tags = new List<string>(),
            Colors = new List<string>(),
            Sizes = new List<string>(),
            Featured = false
        }).ToList();
    }

    public async Task<List<ProductModel>> GetRandomAsync(int count)
    {
        var products = await _context.Produkty
            .AsNoTracking()
            .OrderBy(p => Guid.NewGuid())
            .Take(count)
            .ToListAsync();

        return products.Select(p => new ProductModel
        {
            Id = p.Id,
            Name = p.Nazwa,
            Price = p.Cena,
            OldPrice = null,
            Discount = null,
            IsNew = false,
            ImageUrl = "/images/place-holder.jpg",
            Tags = new List<string>(),
            Colors = new List<string>(),
            Sizes = new List<string>(),
            Featured = false
        }).ToList();
    }

    public async Task<List<ProductModel>> SearchAsync(string? query, string? category, decimal? minPrice, decimal? maxPrice)
    {
        var q = _context.Produkty.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(query))
            q = q.Where(p => EF.Functions.Like(p.Nazwa, $"%{query}%"));
        if (!string.IsNullOrWhiteSpace(category))
            q = q.Where(p => p.Kategoria == category);
        if (minPrice.HasValue)
            q = q.Where(p => p.Cena >= minPrice.Value);
        if (maxPrice.HasValue)
            q = q.Where(p => p.Cena <= maxPrice.Value);

        var products = await q.ToListAsync();

        return products.Select(p => new ProductModel
        {
            Id = p.Id,
            Name = p.Nazwa,
            Price = p.Cena,
            OldPrice = null,
            Discount = null,
            IsNew = false,
            ImageUrl = "/images/place-holder.jpg",
            Tags = new List<string>(),
            Colors = new List<string>(),
            Sizes = new List<string>(),
            Featured = false
        }).ToList();
    }

    public async Task<List<string>> GetCategoriesAsync()
    {
        return await _context.Produkty
            .AsNoTracking()
            .Select(p => p.Kategoria!)
            .Where(c => c != null && c != "")
            .Distinct()
            .OrderBy(c => c)
            .ToListAsync();
    }
}
