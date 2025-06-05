using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Intranet.Models;
using FashionStore.Models;

namespace Portal.Services;

public class CartService : ICartService
{
    private const string SessionKey = "CartItems";
    private readonly IntranetContext _context;
    private readonly IHttpContextAccessor _accessor;

    public CartService(IntranetContext context, IHttpContextAccessor accessor)
    {
        _context = context;
        _accessor = accessor;
    }

    private ISession Session => _accessor.HttpContext!.Session;

    private Dictionary<int, int> GetCart()
    {
        var json = Session.GetString(SessionKey);
        if (json == null) return new();
        return JsonSerializer.Deserialize<Dictionary<int, int>>(json) ?? new();
    }

    private void SaveCart(Dictionary<int, int> cart)
    {
        var json = JsonSerializer.Serialize(cart);
        Session.SetString(SessionKey, json);
    }

    public Task AddItemAsync(int productId, int quantity = 1)
    {
        var cart = GetCart();
        if (cart.ContainsKey(productId))
            cart[productId] += quantity;
        else
            cart[productId] = quantity;
        SaveCart(cart);
        return Task.CompletedTask;
    }

    public Task UpdateQuantityAsync(int productId, int quantity)
    {
        var cart = GetCart();
        if (cart.ContainsKey(productId))
        {
            if (quantity <= 0)
                cart.Remove(productId);
            else
                cart[productId] = quantity;
        }
        SaveCart(cart);
        return Task.CompletedTask;
    }

    public Task RemoveItemAsync(int productId)
    {
        var cart = GetCart();
        cart.Remove(productId);
        SaveCart(cart);
        return Task.CompletedTask;
    }

    public Task ClearAsync()
    {
        SaveCart(new());
        return Task.CompletedTask;
    }

    public async Task<List<CartItemModel>> GetItemsAsync()
    {
        var cart = GetCart();
        if (cart.Count == 0) return new();
        var ids = cart.Keys.ToList();
        var products = await _context.Produkty
            .AsNoTracking()
            .Where(p => ids.Contains(p.Id))
            .ToListAsync();

        return products.Select(p => new CartItemModel
        {
            Id = p.Id,
            Name = p.Nazwa,
            Price = p.Cena,
            Quantity = cart[p.Id],
            ImageUrl = "/images/place-holder.jpg",
            Size = string.Empty,
            Color = string.Empty
        }).ToList();
    }
}
