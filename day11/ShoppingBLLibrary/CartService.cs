using ShoppingModelLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartService
    {
        private CartBL cartBL;

        public CartService()
        {
            cartBL = new CartBL();
        }

        public async Task<Cart> AddCartAsync(int customerId, List<Product> products)
        {
            return await cartBL.AddCartAsync(customerId, products);
        }
    }
}
