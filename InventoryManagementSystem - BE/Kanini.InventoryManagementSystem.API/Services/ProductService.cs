using Kanini.InventoryManagementSystem.API.Caching;
using Kanini.InventoryManagementSystem.API.Interfaces;
using Kanini.InventoryManagementSystem.API.Models;
using Kanini.InventoryManagementSystem.API.Models.DataTransferObjects;
using Microsoft.Extensions.Caching.Distributed;

namespace Kanini.InventoryManagementSystem.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IDistributedCache _cache;

        public ProductService(IProductRepository productRepository, IDistributedCache cache)
        {
            _productRepository = productRepository;
            _cache = cache;
        }
        public async Task<Product> CreateProduct(ProductForCreationDto product)
        {
            var createdProduct = await _productRepository.CreateProduct(product);
            await _cache.CacheProductDetails(createdProduct);
            return createdProduct;
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<Product> GetProduct(int id)
        {
            var cachedProduct = await _cache.GetCachedProductDetails(id);
            if (cachedProduct != null)
            {
                return cachedProduct;
            }
            var product = await _productRepository.GetProduct(id);
            await _cache.CacheProductDetails(product);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return products;
        }

        public async Task UpdateProductByQuantity(int id, ProductQuantityForUpdateDto product)
        {
            await _productRepository.UpdateProduct(id, product);
        }
    }
}
