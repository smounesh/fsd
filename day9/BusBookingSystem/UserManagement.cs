using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BusBookingSystem
{
    class UserManagement
    {
        private Dictionary<string, (string hashedPassword, UserRole role)> users; // Simulating user data storage, replace with database

        public UserManagement()
        {
            users = new Dictionary<string, (string, UserRole)>();
        }

        public void SignUp(string username, string password)
        {
            // Check if username already exists
            if (users.ContainsKey(username))
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
                return;
            }

            // Hash the password before storing
            string hashedPassword = HashPassword(password);

            // Determine user role
            UserRole role = users.Count == 0 ? UserRole.Admin : UserRole.Passenger;

            // Add user to the dictionary
            users.Add(username, (hashedPassword, role));

            Console.WriteLine("Sign up successful! Please sign in to continue.");
        }

        public bool SignIn(string username, string password, out UserRole role)
        {
            if (users.TryGetValue(username, out var user))
            {
                // Verify password
                if (VerifyPassword(password, user.hashedPassword))
                {
                    role = user.role;
                    return true;
                }
            }

            role = UserRole.None;
            return false;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }
    }

    public enum UserRole
    {
        None,
        Admin,
        Passenger
    }
}
