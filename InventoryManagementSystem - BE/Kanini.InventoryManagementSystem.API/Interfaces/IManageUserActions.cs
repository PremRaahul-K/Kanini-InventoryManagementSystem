using Kanini.InventoryManagementSystem.API.Models.DataTransferObjects;

namespace Kanini.InventoryManagementSystem.API.Interfaces
{
    public interface IManageUserActions
    {
        public Task<UserForResponseDto> Login(UserForLoginDto user);
        public Task<UserForResponseDto> Register(UserForRegistrationDto user);

    }
}
