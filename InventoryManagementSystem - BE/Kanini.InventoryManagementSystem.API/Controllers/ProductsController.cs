using Kanini.InventoryManagementSystem.API.Models;
using Kanini.InventoryManagementSystem.API.Models.DataTransferObjects;
using Kanini.InventoryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Kanini.InventoryManagementSystem.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Kanini.InventoryManagementSystem.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    [EnableCors("MyCors")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "ProductById")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductForCreationDto product)
        {
            try
            {
                var createdProduct = await _productService.CreateProduct(product);
                return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "WarehouseManager")]
        public async Task<IActionResult> UpdateProductQuantity(int id, ProductQuantityForUpdateDto product)
        {
            try
            {
                var dbProduct = await _productService.GetProduct(id);
                if (dbProduct == null)
                    return NotFound();
                await _productService.UpdateProductByQuantity(id, product);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var dbProduct = await _productService.GetProduct(id);
                if (dbProduct == null)
                    return NotFound();
                await _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
