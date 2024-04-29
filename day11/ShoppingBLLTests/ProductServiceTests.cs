using NUnit.Framework;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System.Threading.Tasks;

namespace ShoppingBLLTests
{
    [TestFixture]
    public class ProductServiceTests
    {
        [Test]
        public async Task GetProductByIdAsync_ValidId_ReturnsProduct()
        {
            // Arrange
            var mockProductRepository = new Mock<ProductRepository>();
            var productService = new ProductService(mockProductRepository.Object);
            var productId = 1;
            var expectedProduct = new Product { Id = productId, Name = "Product 1", Price = 10.0 }; // Mock expected product

            // Set up mock behavior
            mockProductRepository.Setup(repo => repo.GetByKeyAsync(productId)).ReturnsAsync(expectedProduct);

            // Act
            var result = await productService.GetProductByIdAsync(productId);

            // Assert
            Assert.AreEqual(expectedProduct, result);
        }

        [Test]
        public async Task GetProductByIdAsync_InvalidId_ReturnsNull()
        {
            // Arrange
            var mockProductRepository = new Mock<ProductRepository>();
            var productService = new ProductService(mockProductRepository.Object);
            var invalidProductId = 999; // An ID that doesn't exist
            Product nullProduct = null; // Simulating the case where no product is found

            // Set up mock behavior
            mockProductRepository.Setup(repo => repo.GetByKeyAsync(invalidProductId)).ReturnsAsync(nullProduct);

            // Act
            var result = await productService.GetProductByIdAsync(invalidProductId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
