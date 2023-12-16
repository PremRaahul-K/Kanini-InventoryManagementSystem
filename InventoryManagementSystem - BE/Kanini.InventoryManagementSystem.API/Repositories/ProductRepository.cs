using Dapper;
using Kanini.InventoryManagementSystem.API.Entities;
using Kanini.InventoryManagementSystem.API.Entities.DapperContext;
using Kanini.InventoryManagementSystem.API.Entities.DataTransferObjects;
using Kanini.InventoryManagementSystem.API.Interfaces;
using System.Data;

namespace Kanini.InventoryManagementSystem.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(ProductForCreationDto product)
        {
            var query = "INSERT INTO Products (Name, Description, Quantity, Price) VALUES (@Name, @Description, @Quantity, @Price)" + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", product.Name, DbType.String);
            parameters.Add("Description", product.Description, DbType.String);
            parameters.Add("Quantity", product.Quantity, DbType.Int32);
            parameters.Add("Price", product.Price, DbType.Double);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var CreatedProduct = new Product
                {
                    Id = id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                };
                return CreatedProduct;
            }
        }

        public async Task DeleteProduct(int id)
        {
            var query = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            var query = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QueryFirstOrDefaultAsync<Product>(query, new {id});
                return product;
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var query = "SELECT * FROM Products";
            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Product>(query);
                return products.ToList();
            }
        }

        public async Task UpdateProduct(int id, ProductQuantityForUpdateDto product)
        {
            var query = "UPDATE Products SET Quantity = @Quantity WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Quantity", product.Quantity, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
