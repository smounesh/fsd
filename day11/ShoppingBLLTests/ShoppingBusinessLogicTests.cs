using NUnit.Framework;
using ShoppingBLLibrary;
using ShoppingModelLibrary;
using System.Collections.Generic;

namespace ShoppingBLLTests
{
    public class ShoppingBusinessLogicTests
    {
        private ShoppingBusinessLogic shoppingBL;

        [SetUp]
        public void Setup()
        {
            shoppingBL = new ShoppingBusinessLogic();
        }

        [Test]
        public void ApplyShippingCharge_TotalLessThan100_ChargesShipping()
        {
            double totalPrice = 90; // Total price less than 100
            double totalPriceWithShipping = shoppingBL.ApplyShippingCharge(totalPrice);
            Assert.AreEqual(190, totalPriceWithShipping);
        }

        [Test]
        public void ApplyShippingCharge_TotalEqualTo100_DoesNotChargeShipping()
        {
            double totalPrice = 100; // Total price equal to 100
            double totalPriceWithShipping = shoppingBL.ApplyShippingCharge(totalPrice);
            Assert.AreEqual(100, totalPriceWithShipping);
        }

        [Test]
        public void ApplyDiscount_CartHasThreeItemsAndTotalPriceIs1500_AppliesDiscount()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem { Price = 500, Quantity = 1 }, // Total: 500
                new CartItem { Price = 500, Quantity = 1 }, // Total: 500
                new CartItem { Price = 500, Quantity = 1 }  // Total: 500
            };
            Cart cart = new Cart { CartItems = cartItems };

            // Act
            double totalPriceWithDiscount = shoppingBL.ApplyDiscount(cart);

            // Assert
            Assert.AreEqual(1425, totalPriceWithDiscount); // 5% discount on total 1500
        }

        [Test]
        public void ApplyDiscount_CartHasThreeItemsAndTotalPriceIsLessThan1500_DoesNotApplyDiscount()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem { Price = 400, Quantity = 1 }, // Total: 400
                new CartItem { Price = 400, Quantity = 1 }, // Total: 400
                new CartItem { Price = 400, Quantity = 1 }  // Total: 400
            };
            Cart cart = new Cart { CartItems = cartItems };

            // Act
            double totalPriceWithDiscount = shoppingBL.ApplyDiscount(cart);

            // Assert
            Assert.AreEqual(1200, totalPriceWithDiscount); // No discount applied
        }

        [Test]
        public void ValidateCartQuantity_ItemsQuantityGreaterThan5_ReturnsFalse()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem { Quantity = 3 },
                new CartItem { Quantity = 4 },
                new CartItem { Quantity = 6 }
            };
            Cart cart = new Cart { CartItems = cartItems };

            // Act
            bool isValid = shoppingBL.ValidateCartQuantity(cart);

            // Assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void ValidateCartQuantity_AllItemsQuantityLessThanOrEqual5_ReturnsTrue()
        {
            // Arrange
            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem { Quantity = 3 },
                new CartItem { Quantity = 4 },
                new CartItem { Quantity = 5 }
            };
            Cart cart = new Cart { CartItems = cartItems };

            // Act
            bool isValid = shoppingBL.ValidateCartQuantity(cart);

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}
