using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        private readonly IEmployeeLoginBL _employeeLoginBL;

        public Program()
        {
            _employeeLoginBL = new EmployeeLoginBL();
        }

        public async Task MainMenu()
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            await ProcessOption();
        }

        private async Task ProcessOption()
        {
            Console.WriteLine("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    await RegisterUser();
                    break;
                case 2:
                    await LoginUser();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    await MainMenu();
                    break;
            }
        }

        private async Task RegisterUser()
        {
            Console.WriteLine("- Register");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Create password:");
            string password = Console.ReadLine();
            Console.WriteLine("Choose your role:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");
            int roleChoice = Convert.ToInt32(Console.ReadLine());
            string role = (roleChoice == 1) ? "Admin" : "User";
            await Register(name, password, role);
        }

        private async Task Register(string name, string password, string role)
        {
            try
            {
                Employee newEmployee = new Employee { Name = name, Password = password, Role = role };
                var result = await _employeeLoginBL.Register(newEmployee);
                Console.WriteLine($"Registration successful. Registered ID: {result.Id}");
                await MainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await MainMenu();
            }
        }

        private async Task LoginUser()
        {
            Console.WriteLine("- Login");
            Console.WriteLine("Please enter your Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            await Login(id, password);
        }

        private async Task Login(int id, string password)
        {
            try
            {
                Employee employee = new Employee { Id = id, Password = password };
                var result = await _employeeLoginBL.Login(employee);
                if (result != null)
                {
                    Console.WriteLine($"Login successful. Welcome, {result.Name}!");

                    // Check user's role
                    if (result.Role.ToLower() == "admin")
                    {
                        await new AdminMenu().Start(result);
                    }
                    else if (result.Role.ToLower() == "user")
                    {
                        await new UserMenu().Start(result);
                    }
                    else
                    {
                        Console.WriteLine("Invalid role.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Employee ID or password. Please try again.");
                    await LoginUser();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await LoginUser();
            }
        }


        public static async Task Main(string[] args)
        {
            await new Program().MainMenu();
        }
    }
}
