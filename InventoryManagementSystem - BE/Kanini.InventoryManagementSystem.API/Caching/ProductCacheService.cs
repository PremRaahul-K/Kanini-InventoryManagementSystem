using System.Text.Json;
using StackExchange.Redis;
using Kanini.InventoryManagementSystem.API.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace Kanini.InventoryManagementSystem.API.Caching
{
    public static class ProductCacheService
    {
        public static async Task CacheProductDetails(this IDistributedCache cache, Product product)
        {
            var key = $"Product:{product.Id}";
            var serializedProduct = JsonSerializer.Serialize(product);
            await cache.SetStringAsync(key, serializedProduct);
        }

        public static async Task<Product> GetCachedProductDetails(this IDistributedCache cache, int productId)
        {
            var key = $"Product:{productId}";
            var cachedProduct = await cache.GetStringAsync(key);

            return cachedProduct != null
                ? JsonSerializer.Deserialize<Product>(cachedProduct)
                : default;
        }
    }
}
