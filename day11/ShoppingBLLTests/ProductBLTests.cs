using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLTests
{
    [TestFixture]
    public class ProductBLTests
    {
        [Test]
        public async Task AddProduct_ValidInput_ReturnsNewProduct()
        {
            // Arrange
            var mockProductRepository = new Mock<ProductRepository>();
            var productBL = new ProductBL(mockProductRepository.Object);
            var name = "Product 1";
            var price = 10.0m;
            var expectedProduct = new Product { Id = 1, Name = name, Price = (double)price }; // Mock expected product

            // Set up mock behavior
            mockProductRepository.Setup(repo => repo.Add(It.IsAny<Product>())).Returns(expectedProduct);

            // Act
            var result = await productBL.AddProduct(name, price);

            // Assert
            Assert.AreEqual(expectedProduct, result);
        }

        [Test]
        public async Task GetProductById_ValidId_ReturnsProduct()
        {
            // Arrange
            var mockProductRepository = new Mock<ProductRepository>();
            var productBL = new ProductBL(mockProductRepository.Object);
            var productId = 1;
            var expectedProduct = new Product { Id = productId, Name = "Product 1", Price = 10.0 }; // Mock expected product

            // Set up mock behavior
            mockProductRepository.Setup(repo => repo.GetByKey(productId)).Returns(expectedProduct);

            // Act
            var result = await productBL.GetProductById(productId);

            // Assert
            Assert.AreEqual(expectedProduct, result);
        }

        [Test]
        public async Task UpdateProduct_ValidInput_ReturnsUpdatedProduct()
        {
            // Arrange
            var mockProductRepository = new Mock<ProductRepository>();
            var productBL = new ProductBL(mockProductRepository.Object);
            var productId = 1;
            var name = "Updated Product";
            var price = 20.0m;
            var expectedUpdatedProduct = new Product { Id = productId, Name = name, Price = (double)price }; // Mock expected updated product

            // Set up mock behavior
            mockProductRepository.Setup(repo => repo.Update(It.IsAny<Product>())).Returns(expectedUpdatedProduct);

            // Act
            var result = await productBL.UpdateProduct(productId, name, price);

            // Assert
            Assert.AreEqual(expectedUpdatedProduct, result);
        }

        [Test]
        public async Task DeleteProduct_ValidId_ReturnsTrue()
        {
            // Arrange
            var mockProductRepository = new Mock<ProductRepository>();
            var productBL = new ProductBL(mockProductRepository.Object);
            var productId = 1;
            var deletedProduct = new Product { Id = productId, Name = "Product 1", Price = 10.0 }; // Mock deleted product

            // Set up mock behavior
            mockProductRepository.Setup(repo => repo.Delete(productId)).Returns(deletedProduct);

            // Act
            var result = await productBL.DeleteProduct(productId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteProduct_InvalidId_ReturnsFalse()
        {
            // Arrange
            var mockProductRepository = new Mock<ProductRepository>();
            var productBL = new ProductBL(mockProductRepository.Object);
            var invalidProductId = 999; // An ID that doesn't exist
            Product nullProduct = null; // Simulating the case where no product is deleted

            // Set up mock behavior
            mockProductRepository.Setup(repo => repo.Delete(invalidProductId)).Returns(nullProduct);

            // Act
            var result = await productBL.DeleteProduct(invalidProductId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
