using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Delete(int key)
        {
            try
            {
                Cart cart = GetByKey(key);
                if (cart != null)
                {
                    items.Remove(cart);
                    return cart;
                }
                else
                {
                    throw new KeyNotFoundException("Cart with the specified key was not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's requirements
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }

        public override Cart GetByKey(int key)
        {
            try
            {
                Cart cart = items.FirstOrDefault(c => c.Id == key);
                if (cart != null)
                {
                    return cart;
                }
                else
                {
                    throw new KeyNotFoundException("Cart with the specified key was not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's requirements
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }

        public override Cart Update(Cart item)
        {
            try
            {
                Cart existingCart = GetByKey(item.Id);
                if (existingCart != null)
                {
                    // Update the existing cart with the properties of the new item
                    existingCart.CustomerId = item.CustomerId;
                    existingCart.CartItems = item.CartItems;
                    // You can update other properties similarly if needed

                    // Optionally, you can return the updated cart
                    return existingCart;
                }
                else
                {
                    throw new KeyNotFoundException("Cart with the specified key was not found.");
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
