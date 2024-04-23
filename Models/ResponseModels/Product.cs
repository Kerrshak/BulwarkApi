namespace BulwarkApi.Models.ResponseModels;

public class ProductResult
{
    public required int ProductId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public decimal? Discount { get; set; }
    public int? Quantity { get; set; }
    public bool PreOrder { get; set; }
    public bool ReStockPlanned { get; set; }
    public DateTime? NextDueIn { get; set; }
    public required int CategoryId { get; set; }
    public bool? OnCustomersWatchList { get; set; }
    public string? ImageUrls { get; set; }
}
