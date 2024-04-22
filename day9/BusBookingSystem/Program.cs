

using System;

namespace BusBookingSystem
{
    class Program
    {

        static UserManagement userManagement = new UserManagement();

        static UserRole currentUserRole = UserRole.None;
        static string currentUsername = null;

        static void Main(string[] args)
        {
            
            while (true)
            {
                PrintMainMenu();

                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int option))
                {
                    HandleOption(option);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }

        static void PrintMainMenu()
        {
            Console.WriteLine("Welcome to Bus Booking System");

            if (currentUsername == null)
            {
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("3. Exit");
            }
            else
            {
                if (currentUserRole == UserRole.Admin)
                {
                    PrintAdminMainMenu();
                }
                else
                {
                    PrintUserMainMenu();
                }
            }

            Console.Write("Choose an option: ");
        }
        static void PrintAdminMainMenu()
        {
            Console.WriteLine("1. User Management");
            Console.WriteLine("2. Admin Management");
            Console.WriteLine("3. Bus Management");
            Console.WriteLine("4. Booking Management");
            Console.WriteLine("5. Logout");
            Console.WriteLine("6. Exit");
        }

        static void PrintUserMainMenu()
        {
            Console.WriteLine("1. Book Ticket");
            Console.WriteLine("2. Cancel Ticket");
            Console.WriteLine("3. View Booking History");
            Console.WriteLine("4. Logout");
            Console.WriteLine("5. Exit");
        }


        static void HandleOption(int option)
        {
            if (currentUsername == null)
            {
                HandleOptionForUnsignedUser(option);
            }
            else
            {
                if (currentUserRole == UserRole.Admin)
                {
                    HandleAdminOption(option);
                }
                else
                {
                    HandleOptionForUser(option);
                }
            }
        }

        static void HandleOptionForUnsignedUser(int option)
        {
            switch (option)
            {
                case 1:
                    SignUp();
                    break;
                case 2:
                    SignIn();
                    break;
                case 3:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void HandleAdminOption(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("User Management...");
                    // Implement user management logic
                    break;
                case 2:
                    Console.WriteLine("Admin Management...");
                    // Implement admin management logic
                    break;
                case 3:
                    Console.WriteLine("Bus Management...");
                    BusManagement.PrintBusManagementMenu(); 
                    BusManagement.HandleBusManagementOption(BusManagement.GetMenuOption());
                    break;
                case 4:
                    Console.WriteLine("Booking Management...");
                    // Implement booking management logic
                    break;
                case 5:
                    Logout();
                    break;
                case 6:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void HandleOptionForUser(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Booking ticket...");
                    UserBookingManagement.BookTicket();
                    break;
                case 2:
                    Console.WriteLine("Canceling ticket...");
                    UserBookingManagement.CancelTicket();
                    break;
                case 3:
                    Console.WriteLine("Viewing booking history...");
                    UserBookingManagement.ViewAllBookings();
                    break;
                case 4:
                    Logout();
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void SignUp()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Sign up the user
            userManagement.SignUp(username, password);
        }

        static void SignIn()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Sign in the user
            if (userManagement.SignIn(username, password, out UserRole role))
            {
                currentUsername = username;
                currentUserRole = role;
                Console.WriteLine("Sign In Successful!");

                // Call the method to handle post-sign in logic
                AfterSignIn();
            }
            else
            {
                Console.WriteLine("Sign In Failed. Invalid username or password.");
            }
        }

        static void AfterSignIn()
        {
            if (currentUserRole == UserRole.Admin)
            {
                // Implement admin-specific post-sign in logic here
                Console.WriteLine("Welcome, Admin! You have access to manage users, routes, etc.");
            }
            else
            {
                // Implement regular user post-sign in logic here
                Console.WriteLine($"Welcome, {currentUsername}! You can book and cancel tickets.");
            }
        }

        public static void Logout()
        {
            // Implement Logout functionality
            Console.WriteLine("Logout functionality...");
            currentUsername = null;
            currentUserRole = UserRole.None;
        }

        static void Exit()
        {
            // Implement Exit functionality
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }

        static void PromoteUserToAdmin()
        {
            // Implement Promote User to Admin functionality
            Console.WriteLine("Promote User to Admin functionality...");
        }
    }
}
