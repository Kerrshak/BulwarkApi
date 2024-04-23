using BulwarkApi.Models.ResponseModels;
using BulwarkApi.Services.Basket;
using Microsoft.AspNetCore.Mvc;

namespace BulwarkApi.Controllers;

[Route("api/[controller]")]
public class ProductController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ProductResult[]>> GetProducts()
    {
        ProductResult[] results = await _productService.FetchProducts();

        return results;
    }
}
