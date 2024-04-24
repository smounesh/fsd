using System;
using System.Linq;

namespace ShoppingFE
{
    public class Program
    {
        public delegate T CalculateDelegate<T>(T n1, T n2);

        public void Calculate<T>(CalculateDelegate<T> cal)
        {
            T n1 = default(T), n2 = default(T);
            // Assuming n1 and n2 can be assigned default values for demonstration
            T result = cal(n1, n2);
            Console.WriteLine($"The result of the calculation is: {result}");
        }

        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Program program = new Program();

            // Example usage with integer addition
            CalculateDelegate<int> intAddition = (num1, num2) => num1 + num2;
            program.Calculate(intAddition);

            // Example usage with double multiplication
            CalculateDelegate<double> doubleMultiplication = (num1, num2) => num1 * num2;
            program.Calculate(doubleMultiplication);

            // Using LINQ's Where method to filter elements
            int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };
            var filteredNumbers = numbers.Where(n => n > 80);
            Console.WriteLine("Filtered numbers greater than 80:");
            foreach (int n in filteredNumbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}
