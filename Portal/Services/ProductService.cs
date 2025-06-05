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

        public ProductService(IntranetContext context)
        {
            _context = context;
        }

        /* ────────────── WYRÓŻNIONE ────────────── */
        public async Task<List<ProductModel>> GetFeaturedAsync(int count = 4)
        {
            var products = await _context.Produkty
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .Take(count)
                .ToListAsync();

            return Map(products);
        }

        /* ────────────── WG KATEGORII ────────────── */
        public async Task<List<ProductModel>> GetByCategoryAsync(string category)
        {
            var products = await _context.Produkty
                .AsNoTracking()
                .Where(p => p.Kategoria == category)
                .ToListAsync();

            return Map(products);
        }

        /* ────────────── LOSOWE ────────────── */
        public async Task<List<ProductModel>> GetRandomAsync(int count)
        {
            var products = await _context.Produkty
                .AsNoTracking()
                .OrderBy(p => Guid.NewGuid())
                .Take(count)
                .ToListAsync();

            return Map(products);
        }

        /* ────────────── WYSZUKIWANIE (nowość Codex) ────────────── */
        public async Task<List<ProductModel>> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new();

            var products = await _context.Produkty
                .AsNoTracking()
                .Where(p => EF.Functions.Like(p.Nazwa, $"%{query}%"))
                .ToListAsync();

            return Map(products);
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
