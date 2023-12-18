using Kanini.InventoryManagementSystem.API.Models.DataTransferObjects;
using Kanini.InventoryManagementSystem.API.Models;

namespace Kanini.InventoryManagementSystem.API.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUser(string userName);
        public Task<bool> CreateUser(UserForCreationDto user);
    }
}
