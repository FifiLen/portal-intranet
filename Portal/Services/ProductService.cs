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
}
