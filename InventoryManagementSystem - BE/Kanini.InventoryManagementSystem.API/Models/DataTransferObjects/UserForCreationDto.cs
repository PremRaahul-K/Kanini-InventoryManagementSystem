namespace Kanini.InventoryManagementSystem.API.Models.DataTransferObjects
{
    public class UserForCreationDto
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordKey { get; set; }
        public string Role { get; set; }
    }
}
