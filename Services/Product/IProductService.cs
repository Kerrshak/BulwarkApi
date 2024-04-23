using BulwarkApi.Models.ResponseModels;

namespace BulwarkApi.Services.Basket;

public interface IProductService
{
    Task<ProductResult[]> FetchProducts();
}
