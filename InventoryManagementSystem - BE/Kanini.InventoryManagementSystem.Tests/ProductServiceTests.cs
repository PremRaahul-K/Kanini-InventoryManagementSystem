using Kanini.InventoryManagementSystem.API.Interfaces;
using Kanini.InventoryManagementSystem.API.Models.DataTransferObjects;
using Kanini.InventoryManagementSystem.API.Services;
using Moq;

namespace Kanini.InventoryManagementSystem.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        [Test]
        public async Task CreateProduct_ShouldCallRepositoryCreate()
        {
            // Arrange
            var repositoryMock = new Mock<IProductRepository>();
            var productService = new ProductService(repositoryMock.Object);
            var productDto = new ProductForCreationDto { Name = "TestProduct", Quantity = 10, Price = 20.0 };

            // Act
            await productService.CreateProduct(productDto);

            // Assert
            repositoryMock.Verify(r => r.CreateProduct(It.IsAny<ProductForCreationDto>()), Times.Once);
        }

        [Test]
        public async Task UpdateProductByQuantity_ShouldCallRepositoryUpdate()
        {
            // Arrange
            var repositoryMock = new Mock<IProductRepository>();
            var productService = new ProductService(repositoryMock.Object);
            var productDto = new ProductQuantityForUpdateDto { Quantity = 5 };

            // Act
            await productService.UpdateProductByQuantity(1, productDto);

            // Assert
            repositoryMock.Verify(r => r.UpdateProduct(1, It.IsAny<ProductQuantityForUpdateDto>()), Times.Once);
        }

        [Test]
        public async Task DeleteProduct_ShouldCallRepositoryDelete()
        {
            // Arrange
            var repositoryMock = new Mock<IProductRepository>();
            var productService = new ProductService(repositoryMock.Object);

            // Act
            await productService.DeleteProduct(1);

            // Assert
            repositoryMock.Verify(r => r.DeleteProduct(1), Times.Once);
        }

        [Test]
        public async Task GetProduct_ShouldCallRepositoryGetProduct()
        {
            // Arrange
            var repositoryMock = new Mock<IProductRepository>();
            var productService = new ProductService(repositoryMock.Object);

            // Act
            await productService.GetProduct(1);

            // Assert
            repositoryMock.Verify(r => r.GetProduct(1), Times.Once);
        }

        [Test]
        public async Task GetProducts_ShouldCallRepositoryGetProducts()
        {
            // Arrange
            var repositoryMock = new Mock<IProductRepository>();
            var productService = new ProductService(repositoryMock.Object);

            // Act
            await productService.GetProducts();

            // Assert
            repositoryMock.Verify(r => r.GetProducts(), Times.Once);
        }
    }
}