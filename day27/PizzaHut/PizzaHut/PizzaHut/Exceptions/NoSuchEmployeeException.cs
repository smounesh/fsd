using System.Runtime.Serialization;

namespace PizzaHut.Exceptions
{
    [Serializable]
    internal class NoSuchEmployeeException : Exception
    {
        string message;
        public NoSuchEmployeeException()
        {
            message = "No such employee present";
        }

        public override string Message => message;
    }
}