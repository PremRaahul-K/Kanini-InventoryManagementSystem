using Kanini.InventoryManagementSystem.API.Interfaces;
using Kanini.InventoryManagementSystem.API.Models;
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
            // Additional assertions to check if the product is added to the repository
            repositoryMock.Verify(r => r.CreateProduct(It.Is<ProductForCreationDto>(p => p.Name == "TestProduct" && p.Quantity == 10 && p.Price == 20.0)), Times.Once);

            // You might want to mock a method to retrieve the added product and then assert its existence
            repositoryMock.Setup(r => r.GetProduct(It.IsAny<int>())).ReturnsAsync(new Product { Id = 1, Name = "TestProduct", Quantity = 10, Price = 20.0 });

            // Act: Retrieve the added product
            var addedProduct = await productService.GetProduct(1);

            // Assert: Check if the retrieved product matches the expected data
            Assert.That(addedProduct, Is.Not.Null);
            Assert.That(addedProduct.Name, Is.EqualTo("TestProduct"));
            Assert.That(addedProduct.Quantity, Is.EqualTo(10));
            Assert.That(addedProduct.Price, Is.EqualTo(20.0));
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