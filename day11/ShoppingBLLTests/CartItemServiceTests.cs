using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLTests
{
    [TestFixture]
    public class CartItemServiceTests
    {
        [Test]
        public async Task AddCartItemAsync_ValidInput_ReturnsNewCartItem()
        {
            // Arrange
            var mockCartItemRepository = new Mock<CartItemRepository>();
            var cartItemService = new CartItemService(mockCartItemRepository.Object);
            var cartId = 1;
            var product = new Product { Id = 1, Name = "Product 1", Price = 10.0m };
            var quantity = 2;
            var expectedCartItem = new CartItem { Id = 1, CartId = cartId, Product = product, Quantity = quantity }; // Mock expected cart item

            // Set up mock behavior
            mockCartItemRepository.Setup(repo => repo.AddAsync(It.IsAny<CartItem>())).ReturnsAsync(expectedCartItem);

            // Act
            var result = await cartItemService.AddCartItemAsync(cartId, product, quantity);

            // Assert
            Assert.AreEqual(expectedCartItem, result);
        }

        [Test]
        public async Task UpdateCartItemAsync_ExistingCartItem_ReturnsUpdatedCartItem()
        {
            // Arrange
            var mockCartItemRepository = new Mock<CartItemRepository>();
            var cartItemService = new CartItemService(mockCartItemRepository.Object);
            var cartItemId = 1;
            var existingCartItem = new CartItem { Id = cartItemId, CartId = 1, Product = new Product { Id = 1, Name = "Product 1", Price = 10.0m }, Quantity = 2 }; // Mock existing cart item
            var updatedQuantity = 3;
            var expectedUpdatedCartItem = new CartItem { Id = cartItemId, CartId = 1, Product = new Product { Id = 1, Name = "Product 1", Price = 10.0m }, Quantity = updatedQuantity }; // Mock expected updated cart item

            // Set up mock behavior
            mockCartItemRepository.Setup(repo => repo.GetByKeyAsync(cartItemId)).ReturnsAsync(existingCartItem);
            mockCartItemRepository.Setup(repo => repo.UpdateAsync(It.IsAny<CartItem>())).ReturnsAsync(expectedUpdatedCartItem);

            // Act
            var result = await cartItemService.UpdateCartItemAsync(cartItemId, updatedQuantity);

            // Assert
            Assert.AreEqual(expectedUpdatedCartItem, result);
        }

        [Test]
        public void UpdateCartItemAsync_NonExistingCartItem_ThrowsCartItemNotFoundException()
        {
            // Arrange
            var mockCartItemRepository = new Mock<CartItemRepository>();
            var cartItemService = new CartItemService(mockCartItemRepository.Object);
            var cartItemId = 999; // An ID that doesn't exist
            var quantity = 3;

            // Set up mock behavior
            mockCartItemRepository.Setup(repo => repo.GetByKeyAsync(cartItemId)).ReturnsAsync((CartItem)null); // Simulating the case where no cart item is found

            // Assert
            Assert.ThrowsAsync<CartItemNotFoundException>(async () => await cartItemService.UpdateCartItemAsync(cartItemId, quantity));
        }
    }
}
