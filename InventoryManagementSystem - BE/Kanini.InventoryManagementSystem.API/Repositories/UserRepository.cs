using System.Data;
using Dapper;
using Kanini.InventoryManagementSystem.API.Interfaces;
using Kanini.InventoryManagementSystem.API.Models;
using Kanini.InventoryManagementSystem.API.Models.DataTransferObjects;
using Kanini.InventoryManagementSystem.API.Models.DapperContext;

namespace Kanini.InventoryManagementSystem.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CreateUser(UserForCreationDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            const string query = "INSERT INTO Users (Username, PasswordHash, PasswordKey, Role) VALUES(@Username, @PasswordHash, @PasswordKey, @Role);";

            var parameters = new DynamicParameters();
            parameters.Add("Username", user.Username, DbType.String);
            parameters.Add("PasswordHash", user.PasswordHash, DbType.Binary);
            parameters.Add("PasswordKey", user.PasswordKey, DbType.Binary);
            parameters.Add("Role", user.Role, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(query, parameters);
                return affectedRows > 0;
            }
        }

        public async Task<User> GetUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(userName));
            }

            const string query = "SELECT * FROM Users WHERE Username = @userName";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>(query, new { userName });
            }
        }
    }
}
