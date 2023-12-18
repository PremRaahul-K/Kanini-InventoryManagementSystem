using System.ComponentModel.DataAnnotations;

namespace Kanini.InventoryManagementSystem.API.Models.DataTransferObjects
{
    public class UserForRegistrationDto:UserForLoginDto
    {
        public string Role { get; set; }
    }
}
