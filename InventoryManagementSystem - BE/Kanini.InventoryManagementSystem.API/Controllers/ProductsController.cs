using Kanini.InventoryManagementSystem.API.Entities;
using Kanini.InventoryManagementSystem.API.Entities.DataTransferObjects;
using Kanini.InventoryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kanini.InventoryManagementSystem.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetProducts();
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
                var product = await _productRepository.GetProduct(id);
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
                var createdProduct = await _productRepository.CreateProduct(product);
                return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductQuantity(int id, ProductQuantityForUpdateDto product)
        {
            try
            {
                var dbProduct = await _productRepository.GetProduct(id);
                if (dbProduct == null)
                    return NotFound();
                await _productRepository.UpdateProduct(id, product);
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
                var dbProduct = await _productRepository.GetProduct(id);
                if (dbProduct == null)
                    return NotFound();
                await _productRepository.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
