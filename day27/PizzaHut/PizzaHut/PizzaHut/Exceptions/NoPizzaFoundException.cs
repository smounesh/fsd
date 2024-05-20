using System;

namespace PizzaHut.Exceptions
{
    public class NoPizzaFoundException : Exception
    {
        public NoPizzaFoundException()
            : base("No pizza found.")
        {
        }

        public NoPizzaFoundException(string message)
            : base(message)
        {
        }

        public NoPizzaFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}