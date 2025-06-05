namespace Portal.Services;

public interface IProductService
{
    Task<List<FashionStore.Models.ProductModel>> GetFeaturedAsync(int count = 4);
    Task<List<FashionStore.Models.ProductModel>> GetByCategoryAsync(string category);
    Task<List<FashionStore.Models.ProductModel>> GetRandomAsync(int count);
    Task<List<FashionStore.Models.ProductModel>> SearchAsync(string? query, string? category, decimal? minPrice, decimal? maxPrice);
    Task<List<string>> GetCategoriesAsync();
}
