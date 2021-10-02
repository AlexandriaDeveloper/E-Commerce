using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infra.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandData = File.ReadAllText("../Infra/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infra/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infra/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var item in products)
                    {
                        context.Products
                        .Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.DeliveryMethods.Any())
                {
                    var dmData = File.ReadAllText("../Infra/Data/SeedData/delivery.json");

                    var deliveryMethod = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);
                    foreach (var item in deliveryMethod)
                    {
                        context.DeliveryMethods
                        .Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {

                var logger = loggerFactory.CreateLogger<StoreContext>();
                logger.LogError(ex, ex.Message);
            }
        }
    }
}