using BulwarkApi.Database;
using BulwarkApi.Models;
using BulwarkApi.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace BulwarkApi.Services.Basket;

public class ProductService
{
    private readonly BulwarkDb DC;

    public ProductService(BulwarkDb bulwarkDb)
    {
        DC = bulwarkDb;
    }

    public async Task<ProductResult[]> FetchProducts()
    {
        int customerId = 0; //PLACEHOLDER

        Product[] products = await DC.Products.Include(p => p.InterestedCustomers.Where(c => c.CustomerId == customerId))
            .AsNoTrackingWithIdentityResolution()
            .Where(p => p.ShowOnStore)
            .ToArrayAsync();

        ProductResult[] results = products.Select(p => new ProductResult()
        {
            ProductId = p.ProductId,
            CategoryId = p.CategoryId,
            Name = p.Name,
            Description = p.Description,
            ImageUrls = p.ImageUrls,
            
            Price = p.Price,
            Discount = p.Discount,
            Quantity = p.Quantity,

            PreOrder = p.PreOrder,
            NextDueIn = p.NextDueIn,
            ReStockPlanned = p.ReStockPlanned,

            OnCustomersWatchList = p.InterestedCustomers.Count > 0
        }).ToArray();

        return results;
    }
}