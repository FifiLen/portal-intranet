namespace FashionStore.Models;

public class CartPageViewModel
{
    public List<CartItemModel> Items { get; set; } = new();
    public List<ProductModel> Recommended { get; set; } = new();
}
