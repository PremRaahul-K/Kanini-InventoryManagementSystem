using Kanini.InventoryManagementSystem.API.Interfaces;
using Kanini.InventoryManagementSystem.API.Models;
using Kanini.InventoryManagementSystem.API.Models.DataTransferObjects;

namespace Kanini.InventoryManagementSystem.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> CreateProduct(ProductForCreationDto product)
        {
            var createdProduct = await _productRepository.CreateProduct(product);
            return createdProduct;
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);    
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
