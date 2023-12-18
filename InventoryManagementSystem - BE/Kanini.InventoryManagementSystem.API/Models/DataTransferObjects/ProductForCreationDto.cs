using System.ComponentModel.DataAnnotations;

namespace Kanini.InventoryManagementSystem.API.Models.DataTransferObjects
{
    public class ProductForCreationDto
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }
    }
}
