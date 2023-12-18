using System.Text.Json.Serialization;

namespace Kanini.InventoryManagementSystem.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordKey { get; set; }
        public string Role { get; set; }
    }
}
