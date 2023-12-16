using Kanini.InventoryManagementSystem.API.Entities.DataTransferObjects;
using Kanini.InventoryManagementSystem.API.Entities;

namespace Kanini.InventoryManagementSystem.API.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUser(int id);
        public Task<User> CreateUser(UserForCreationDto user);
    }
}
