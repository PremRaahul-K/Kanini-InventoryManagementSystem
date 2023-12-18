namespace Kanini.InventoryManagementSystem.API.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(string userName,string userRole);
    }
}
