using Microsoft.Extensions.Configuration;

namespace BulwarkApi.Models;

public static class Settings
{
    private static int _quantityForLowStock { get; set; }
    public static int QuantityForLowStock
    {
        get { return _quantityForLowStock; }
        set { _quantityForLowStock = value; }
    }

    public static void ConfigureSettings(IConfiguration configuration)
    {
        QuantityForLowStock = configuration.GetSection("QuantityForLowStock").Get<int>();
    }
}
