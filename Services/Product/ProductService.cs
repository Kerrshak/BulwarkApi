using BulwarkApi.Database;
using BulwarkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BulwarkApi.Services.Basket;

public class ProductService
{
    private readonly BulwarkDb DC;

    public ProductService(BulwarkDb bulwarkDb)
    {
        DC = bulwarkDb;
    }

    public async Task<Product[]> FetchProducts()
    {
        Product[] products = await DC.Products.AsNoTrackingWithIdentityResolution()
            .Where(p => p.ShowOnStore)
            .ToArrayAsync();

        return products;
    }
}