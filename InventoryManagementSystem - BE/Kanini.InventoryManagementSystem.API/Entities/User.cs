using System.Text.Json.Serialization;

namespace Kanini.InventoryManagementSystem.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordKey { get; set; }
        public string Role { get; set; }
    }
}
