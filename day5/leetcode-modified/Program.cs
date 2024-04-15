using System;

class Program
{
    static void Main(string[] args)
    {
        string secretWord = "golf"; // Change the secret word here
        int cows, bulls;
        Console.WriteLine("Welcome to Cow and Bull game!");
        Console.WriteLine("Guess the 4-letter word. You'll get feedback after each guess.");
        do
        {
            Console.Write("Enter your guess: ");
            string guess = Console.ReadLine().ToLower();
            (cows, bulls) = CalculateCowsAndBulls(secretWord, guess);
            Console.WriteLine($"Cows: {cows}, Bulls: {bulls}");
        } while (cows < 4);
        Console.WriteLine("Congratulations!!! You won!");
    }

    static (int, int) CalculateCowsAndBulls(string secretWord, string guess)
    {
        int cows = 0, bulls = 0;
        for (int i = 0; i < 4; i++)
        {
            if (secretWord[i] == guess[i])
            {
                bulls++;
            }
            else if (secretWord.Contains(guess[i]))
            {
                cows++;
            }
        }
        return (cows, bulls);
    }
}
