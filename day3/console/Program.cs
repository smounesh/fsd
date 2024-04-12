// Q1:  Takes two numbers and performs the specified operation
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int sum = num1 + num2;
        int product = num1 * num2;
        int quotient = num1 / num2;
        int difference = num1 - num2;
        int remainder = num1 % num2;

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Product: " + product);
        Console.WriteLine("Quotient: " + quotient);
        Console.WriteLine("Difference: " + difference);
        Console.WriteLine("Remainder: " + remainder);
    }
}

// Q2: Take inputs until the user enters a negative number and finds the greatest of the given numbers

class Program
{
    static void Main(string[] args)
    {
        int greatest = int.MinValue;

        while (true)
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num <= -1)
            {
                break;
            }

            if (num > greatest)
            {
                greatest = num;
            }
        }

        Console.WriteLine("Greatest number: " + greatest);
    }
}

// Q3: Take inputs until the user enters a negative number and finds the average of all the numbers that are divisible by 7
class Program
{
    static void Main(string[] args)
    {
        int count = 0;
        int sum = 0;

        while (true)
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num <= -1)
            {
                break;
            }

            if (num % 7 == 0)
            {
                count++;
                sum += num;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No numbers are divisible by 7.");
        }
        else
        {
            double average = (double)sum / count;
            Console.WriteLine("Average of numbers divisible by 7: " + average);
        }
    }
}

// Q4: Length of the given user's name

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        int length = name.Length;
        Console.WriteLine("Length of your name: " + length);
    }
}

// Q5: Check username is "ABC" and pass is "123". Exit after 3 wrong attempts
class Program
{
    static void Main(string[] args)
    {
        const string correctUsername = "ABC";
        const string correctPassword = "123";
        int attempts = 0;

        while (attempts < 3)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (username == correctUsername && password == correctPassword)
            {
                Console.WriteLine("Login successful!");
                return;
            }

            Console.WriteLine("Invalid username or password.");
            attempts++;
        }

        Console.WriteLine("You have exceeded the number of attempts.");
    }
}

// Q6:  Takes a string from the user with words separated by commas, separates the words, and finds the word with the least number of repeating vowels.

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a string with words separated by commas: ");
        string input = Console.ReadLine();

        string[] words = input.Split(',');
        int minVowelCount = int.MaxValue;
        string[] minCountWords = new string[0];

        foreach (string word in words)
        {
            int vowelCount = word.Count(c => "aeiou".Contains(char.ToLower(c)));
            if (vowelCount < minVowelCount)
            {
                minVowelCount = vowelCount;
                minCountWords = new[] { word };
            }
            else if (vowelCount == minVowelCount)
            {
                Array.Resize(ref minCountWords, minCountWords.Length + 1);
                minCountWords[minCountWords.Length - 1] = word;
            }
        }

        Console.WriteLine("Words with the least number of repeating vowels:");
        foreach (string word in minCountWords)
        {
            Console.WriteLine(word);
        }
    }
}