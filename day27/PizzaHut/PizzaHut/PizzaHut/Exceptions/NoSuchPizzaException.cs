namespace PizzaHut.Exceptions
{
    public class NoSuchPizzaException : Exception
    {
        public NoSuchPizzaException() : base("Pizza not found.")
        {
        }
    }
}