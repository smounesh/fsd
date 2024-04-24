using ShoppingModelLibrary;
using System;
using System.Linq;

namespace ShoppingBLLibrary
{
    public class ShoppingBusinessLogic
    {
        public double CalculateTotalPrice(Cart cart)
        {
            double totalPrice = cart.CartItems.Sum(item => item.Price * item.Quantity);
            return totalPrice;
        }

        public double ApplyShippingCharge(double totalPrice)
        {
            if (totalPrice < 100)
            {
                totalPrice += 100;
            }
            return totalPrice;
        }


        public double ApplyDiscount(Cart cart)
        {
            double totalPrice = CalculateTotalPrice(cart);

            if (cart.CartItems.Count == 3 && totalPrice >= 1500)
            {
                double discountAmount = totalPrice * 0.05; 
                totalPrice -= discountAmount;
            }

            return totalPrice;
        }


        public bool ValidateCartQuantity(Cart cart)
        {
            foreach (var item in cart.CartItems)
            {
                if (item.Quantity > 5)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
