using Kanini.InventoryManagementSystem.API.Entities;
using Kanini.InventoryManagementSystem.API.Entities.DapperContext;
using Kanini.InventoryManagementSystem.API.Entities.DataTransferObjects;
using Kanini.InventoryManagementSystem.API.Interfaces;

namespace Kanini.InventoryManagementSystem.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }
        public Task<User> CreateUser(UserForCreationDto user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
