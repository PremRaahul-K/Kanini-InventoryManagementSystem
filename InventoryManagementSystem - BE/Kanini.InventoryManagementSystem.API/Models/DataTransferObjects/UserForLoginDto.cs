using System.ComponentModel.DataAnnotations;

namespace Kanini.InventoryManagementSystem.API.Models.DataTransferObjects
{
    public class UserForLoginDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }
    }
}
