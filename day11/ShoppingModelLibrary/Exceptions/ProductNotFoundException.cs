using System;

namespace ShoppingDALLibrary
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException()
            : base("No product found with the given ID.")
        {
        }

        public ProductNotFoundException(string message)
            : base(message)
        {
        }

        public ProductNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
