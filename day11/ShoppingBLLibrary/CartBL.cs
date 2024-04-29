using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBL
    {
        private CartRepository cartRepository;

        public CartBL()
        {
            cartRepository = new CartRepository();
        }

        public async Task<Cart> AddCartAsync(int customerId, List<Product> products)
        {
            // Create a new cart instance
            Cart newCart = new Cart
            {
                Id = GenerateCartId(),
                CustomerId = customerId,
                CartItems = new List<CartItem>()
            };

            // Add products to the cart
            foreach (Product product in products)
            {
                newCart.CartItems.Add(new CartItem { Product = product, Quantity = 1 }); // Assuming default quantity is 1
            }

            // Add the cart to the repository asynchronously
            await cartRepository.AddAsync(newCart);

            return newCart;
        }

        // Example method for generating unique cart IDs
        private int GenerateCartId()
        {
            // Implement your logic for generating unique IDs here
            // For simplicity, let's assume it returns a random number for now
            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}
