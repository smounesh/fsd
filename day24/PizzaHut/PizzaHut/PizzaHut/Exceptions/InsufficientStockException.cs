using System;

namespace PizzaHut.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException() : base("Insufficient stock for the requested quantity.")
        {
        }

        public InsufficientStockException(string message) : base(message)
        {
        }

        public InsufficientStockException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}