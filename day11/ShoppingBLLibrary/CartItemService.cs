using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartItemService
    {
        private CartItemRepository cartItemRepository;

        public CartItemService()
        {
            cartItemRepository = new CartItemRepository();
        }

        public async Task<CartItem> AddCartItemAsync(int cartId, Product product, int quantity)
        {
            CartItem cartItem = new CartItem { CartId = cartId, Product = product, Quantity = quantity };
            return await cartItemRepository.AddAsync(cartItem);
        }

        public async Task<CartItem> UpdateCartItemAsync(int cartItemId, int quantity)
        {
            CartItem cartItem = await cartItemRepository.GetByKeyAsync(cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                return await cartItemRepository.UpdateAsync(cartItem);
            }
            else
            {
                throw new CartItemNotFoundException($"CartItem with ID {cartItemId} not found.");
            }
        }
    }
}
