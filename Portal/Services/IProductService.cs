namespace Portal.Services;

public interface IProductService
{
    Task<List<FashionStore.Models.ProductModel>> GetFeaturedAsync(int count = 4);
    Task<List<FashionStore.Models.ProductModel>> GetByCategoryAsync(string category);
}
