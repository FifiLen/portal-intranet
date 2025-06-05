using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intranet.Models;
using FashionStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Portal.Services
{
    public class ProductService : IProductService
    {
        private readonly IntranetContext _context;

        public ProductService(IntranetContext context) => _context = context;

        /* ────────────── 1. WYRÓŻNIONE ────────────── */
        public async Task<List<ProductModel>> GetFeaturedAsync(int count = 4)
        {
            var products = await _context.Produkty
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .Take(count)
                .ToListAsync();

            return Map(products);
        }

        /* ────────────── 2. WG KATEGORII ────────────── */
        public async Task<List<ProductModel>> GetByCategoryAsync(string category)
        {
            var products = await _context.Produkty
                .AsNoTracking()
                .Where(p => p.Kategoria == category)
                .ToListAsync();

            return Map(products);
        }

        /* ────────────── 3. LOSOWE ────────────── */
        public async Task<List<ProductModel>> GetRandomAsync(int count)
        {
            var products = await _context.Produkty
                .AsNoTracking()
                .OrderBy(_ => Guid.NewGuid())
                .Take(count)
                .ToListAsync();

            return Map(products);
        }

        /* ────────────── 4. ROZSZERZONE WYSZUKIWANIE ────────────── */
        public async Task<List<ProductModel>> SearchAsync(
            string? query,
            string? category = null,
            decimal? minPrice = null,
            decimal? maxPrice = null)
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
            return Map(products);
        }

        /* ────────────── 5. LISTA KATEGORII ────────────── */
        public async Task<List<string>> GetCategoriesAsync()
        {
            return await _context.Produkty
                .AsNoTracking()
                .Select(p => p.Kategoria!)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();
        }

        /* ────────────── MAPOWANIE ENTITY → VIEWMODEL ────────────── */
        private static List<ProductModel> Map(IEnumerable<Produkt> products) =>
            products.Select(p => new ProductModel
            {
                Id       = p.Id,
                Name     = p.Nazwa,
                Price    = p.Cena,
                OldPrice = null,
                Discount = null,
                IsNew    = false,
                ImageUrl = "/images/place-holder.jpg",
                Tags     = new List<string>(),
                Colors   = new List<string>(),
                Sizes    = new List<string>(),
                Featured = false
            }).ToList();
    }
}
