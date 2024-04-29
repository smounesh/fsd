using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLTests
{
    [TestFixture]
    public class CartBLTests
    {
        [Test]
        public async Task AddCartAsync_ValidInput_ReturnsNewCart()
        {
            // Arrange
            var mockCartRepository = new Mock<CartRepository>();
            var cartBL = new CartBL(mockCartRepository.Object);
            var customerId = 1;
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.0m },
                new Product { Id = 2, Name = "Product 2", Price = 20.0m }
            };
            var expectedCartId = 1234; // Mock expected cart ID

            // Set up mock behavior
            mockCartRepository.Setup(repo => repo.AddAsync(It.IsAny<Cart>())).Callback((Cart cart) => cart.Id = expectedCartId);

            // Act
            var result = await cartBL.AddCartAsync(customerId, products);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCartId, result.Id);
            Assert.AreEqual(customerId, result.CustomerId);
            Assert.AreEqual(products.Count, result.CartItems.Count);
            foreach (var product in products)
            {
                Assert.IsTrue(result.CartItems.Exists(item => item.Product == product));
            }
        }
    }
}
