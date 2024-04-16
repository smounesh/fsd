// Q1:  A Doctor class with details

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Exp { get; set; }
    public string Qualification { get; set; }
    public string Speciality { get; set; }
}

// Q2: Array of doctors

Doctor[] doctors = new Doctor[]
{
    new Doctor { Id = 1, Name = "John Doe", Age = 35, Exp = 10, Qualification = "MD", Speciality = "Cardiology" },
    new Doctor { Id = 2, Name = "Jane Doe", Age = 40, Exp = 12, Qualification = "PhD", Speciality = "Neurology" },
    new Doctor { Id = 3, Name = "Bob Smith", Age = 50, Exp = 20, Qualification = "MD", Speciality = "Oncology" },
    // add more doctors as needed
};

// Q3: Print the array

foreach (Doctor doctor in doctors)
{
    Console.WriteLine($"Id: {doctor.Id}, Name: {doctor.Name}, Age: {doctor.Age}, Exp: {doctor.Exp}, Qualification: {doctor.Qualification}, Speciality: {doctor.Speciality}");
}

// Q4: Given a speciality, print the doctor details in it

string speciality = "Cardiology";

Doctor matchingDoctor = doctors.FirstOrDefault(d => d.Speciality == speciality);

if (matchingDoctor != null)
{
    Console.WriteLine($"Doctor with speciality {speciality}:");
    Console.WriteLine($"Id: {matchingDoctor.Id}, Name: {matchingDoctor.Name}, Age: {matchingDoctor.Age}, Exp: {matchingDoctor.Exp}, Qualification: {matchingDoctor.Qualification}, Speciality: {matchingDoctor.Speciality}");
}
else
{
    Console.WriteLine($"No doctor found with speciality {speciality}.");
}

// Q5: Validate Card
using System;

namespace Application
{
    public class CardValidator
    {
        public static bool ValidateCardNumber(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                Console.WriteLine("Invalid Card number cannot be empty or whitespace.");
                return false;
            }

            if (!IsNumeric(cardNumber) || !HasValidLength(cardNumber))
            {
                Console.WriteLine("Invalid Card number format.");
                return false;
            }

            return LuhnAlgorithmCheck(cardNumber);
        }

        private static bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private static bool HasValidLength(string input)
        {
            return input.Length == 16;
        }

        private static bool LuhnAlgorithmCheck(string cardNumber)
        {
            char[] cardDigits = cardNumber.ToCharArray();
            Array.Reverse(cardDigits);

            int sum = 0;
            for (int i = 0; i < cardDigits.Length; i++)
            {
                int digit = cardDigits[i] - '0'; // Convert char to int

                if (i % 2 == 1)
                {
                    digit *= 2;
                    digit = (digit < 10) ? digit : digit - 9; // If double digit, sum the digits
                }
                sum += digit;
            }

            return sum % 10 == 0;
        }

        public static string GetValidCardNumber()
        {
            string cardNumber;
            bool isValid = false;

            do
            {
                Console.WriteLine("Enter 16-digit card number:");
                cardNumber = Console.ReadLine();

                if (ValidateCardNumber(cardNumber))
                {
                    isValid = true;
                }
            } while (!isValid);

            return cardNumber;
        }
    }
} 
