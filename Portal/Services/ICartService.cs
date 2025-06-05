namespace Portal.Services;

public interface ICartService
{
    Task AddItemAsync(int productId, int quantity = 1);
    Task UpdateQuantityAsync(int productId, int quantity);
    Task RemoveItemAsync(int productId);
    Task ClearAsync();
    Task<List<FashionStore.Models.CartItemModel>> GetItemsAsync();
}
