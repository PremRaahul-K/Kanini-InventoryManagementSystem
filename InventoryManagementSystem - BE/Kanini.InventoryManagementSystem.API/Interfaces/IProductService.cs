using Kanini.InventoryManagementSystem.API.Models.DataTransferObjects;
using Kanini.InventoryManagementSystem.API.Models;

namespace Kanini.InventoryManagementSystem.API.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProduct(int id);
        public Task<Product> CreateProduct(ProductForCreationDto product);
        public Task UpdateProductByQuantity(int id, ProductQuantityForUpdateDto product);
        public Task DeleteProduct(int id);
    }
}
