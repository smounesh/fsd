using System;

namespace PizzaHut.Exceptions
{
    public class NoSuchOrderException : Exception
    {
        public NoSuchOrderException() : base("No such order found.")
        {
        }

        public NoSuchOrderException(string message) : base(message)
        {
        }

        public NoSuchOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}