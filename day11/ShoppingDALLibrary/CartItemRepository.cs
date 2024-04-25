using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override CartItem Delete(int key)
        {
            try
            {
                CartItem cartItem = GetByKey(key);
                if (cartItem != null)
                {
                    items.Remove(cartItem);
                    return cartItem;
                }
                else
                {
                    throw new KeyNotFoundException("Cart item with the specified key was not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's requirements
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }

        public override CartItem GetByKey(int key)
        {
            try
            {
                CartItem cartItem = items.FirstOrDefault(ci => ci.CartId == key);
                if (cartItem != null)
                {
                    return cartItem;
                }
                else
                {
                    throw new KeyNotFoundException("Cart item with the specified key was not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's requirements
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }

        public override CartItem Update(CartItem item)
        {
            try
            {
                CartItem existingCartItem = GetByKey(item.CartId);
                if (existingCartItem != null)
                {
                    // Update the existing cart item with the properties of the new item
                    existingCartItem.ProductId = item.ProductId;
                    existingCartItem.Quantity = item.Quantity;
                    // You can update other properties similarly if needed

                    // Optionally, you can return the updated cart item
                    return existingCartItem;
                }
                else
                {
                    throw new KeyNotFoundException("Cart item with the specified key was not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's requirements
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }
    }
}
