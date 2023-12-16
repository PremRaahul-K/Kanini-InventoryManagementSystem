using System.ComponentModel.DataAnnotations;

namespace Kanini.InventoryManagementSystem.API.Entities.DataTransferObjects
{
    public class ProductQuantityForUpdateDto
    {

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }
    }
}
