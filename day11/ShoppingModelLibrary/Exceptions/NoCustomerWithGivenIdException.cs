using System;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCustomerWithGivenIdException : Exception
    {
        public NoCustomerWithGivenIdException() : base("No customer found with the given ID.")
        {
        }

        public NoCustomerWithGivenIdException(string message) : base(message)
        {
        }

        public NoCustomerWithGivenIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
