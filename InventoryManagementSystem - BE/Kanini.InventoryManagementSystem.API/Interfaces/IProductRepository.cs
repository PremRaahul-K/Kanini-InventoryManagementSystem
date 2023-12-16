using Kanini.InventoryManagementSystem.API.Entities;
using Kanini.InventoryManagementSystem.API.Entities.DataTransferObjects;

namespace Kanini.InventoryManagementSystem.API.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProduct(int id);
        public Task<Product> CreateProduct(ProductForCreationDto product);
        public Task UpdateProduct(int id, ProductQuantityForUpdateDto product);
        public Task DeleteProduct(int id);
    }
}
