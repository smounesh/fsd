using NUnit.Framework;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;

namespace ShoppingDALLibrary.Tests
{
    [TestFixture]
    public class CartItemRepositoryTests
    {
        private CartItemRepository repository;

        [SetUp]
        public void SetUp()
        {
            repository = new CartItemRepository();
        }

        [Test]
        public void TestAddAndGetCartItem()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 2 };

            // Act
            repository.Add(cartItem);
            CartItem retrievedCartItem = repository.GetByKey(cartItem.CartId);

            // Assert
            Assert.IsNotNull(retrievedCartItem);
            Assert.AreEqual(cartItem.CartId, retrievedCartItem.CartId);
            Assert.AreEqual(cartItem.ProductId, retrievedCartItem.ProductId);
            Assert.AreEqual(cartItem.Quantity, retrievedCartItem.Quantity);
        }

        [Test]
        public void TestUpdateCartItem()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 2 };
            repository.Add(cartItem);

            CartItem updatedCartItem = new CartItem { CartId = 1, ProductId = 2, Quantity = 3 };

            // Act
            CartItem updated = repository.Update(updatedCartItem);

            // Assert
            Assert.IsNotNull(updated);
            Assert.AreEqual(updatedCartItem.CartId, updated.CartId);
            Assert.AreEqual(updatedCartItem.ProductId, updated.ProductId);
            Assert.AreEqual(updatedCartItem.Quantity, updated.Quantity);
        }

        [Test]
        public void TestDeleteCartItem()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 2 };
            repository.Add(cartItem);

            // Act
            CartItem deleted = repository.Delete(cartItem.CartId);

            // Assert
            Assert.IsNotNull(deleted);
            Assert.AreEqual(cartItem.CartId, deleted.CartId);
            Assert.AreEqual(cartItem.ProductId, deleted.ProductId);
            Assert.AreEqual(cartItem.Quantity, deleted.Quantity);

            // Ensure that the deleted item is no longer in the repository
            Assert.Throws<KeyNotFoundException>(() => repository.GetByKey(cartItem.CartId));
        }

        [Test]
        public void TestGetNonExistentCartItem()
        {
            // Arrange

            // Act
            Assert.Throws<KeyNotFoundException>(() => repository.GetByKey(1));
        }

        [Test]
        public void TestUpdateNonExistentCartItem()
        {
            // Arrange
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 2 };

            // Act
            Assert.Throws<KeyNotFoundException>(() => repository.Update(cartItem));
        }

        [Test]
        public void TestDeleteNonExistentCartItem()
        {
            // Arrange

            // Act
            Assert.Throws<KeyNotFoundException>(() => repository.Delete(1));
        }
    }
}
