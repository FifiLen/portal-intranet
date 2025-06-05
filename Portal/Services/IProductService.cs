namespace Portal.Services;

public interface IProductService
{
    Task<List<FashionStore.Models.ProductModel>> GetFeaturedAsync(int count = 4);
    Task<List<FashionStore.Models.ProductModel>> GetByCategoryAsync(string category);
    Task<List<FashionStore.Models.ProductModel>> GetRandomAsync(int count);

    // Rozszerzone wyszukiwanie (query + filtry)
    Task<List<FashionStore.Models.ProductModel>> SearchAsync(
        string? query,
        string? category = null,
        decimal? minPrice = null,
        decimal? maxPrice = null);

    // Lista dostępnych kategorii (np. do dropdownu w wyszukiwarce)
    Task<List<string>> GetCategoriesAsync();
}
