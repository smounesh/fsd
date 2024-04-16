using System;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication
{
    internal class Program
    {
        private Employee[] employees;

        public Program()
        {
            employees = new Employee[3];
        }

        private void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Search & Update Employee Name by ID");
            Console.WriteLine("5. Search & Delete Employee by ID");
            Console.WriteLine("0. Exit");
        }

        private void EmployeeInteraction()
        {
            int choice = 0;

            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        SearchAndUpdateNameOfEmployee();
                        break;
                    case 5:
                        SearchAndDeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        private void AddEmployee()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                    break;
                }
            }
        }

        private void PrintAllEmployees()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }

        private int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }

        private void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }

        private void SearchAndUpdateNameOfEmployee()
        {
            Console.WriteLine("Please enter Employee ID to update name : ");
            int id = GetIdFromConsole();
            Employee? employee = SearchEmployeeById(id);

            if (employee == null)
            {
                Console.WriteLine("Sorry, Employee ID is invalid!!!");
                return;
            }

            Console.WriteLine("Employee ID : " + id);
            PrintEmployee(employee);
            Console.WriteLine("Please enter new name : ");
            string? newname = Console.ReadLine() ?? string.Empty;
            employee.Name = newname;
            Console.WriteLine("\n Employee updated !!!");
            PrintEmployee(employee);

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i]?.Id == id)
                {
                    employees[i] = employee;
                    break;
                }
            }
        }

        private void SearchAndDeleteEmployee()
        {
            Console.WriteLine("Please enter ID to be deleted : ");
            int id = GetIdFromConsole();

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i]?.Id == id)
                {
                    employees[i] = null;
                    Console.WriteLine("Employee ID found and deleted!!!");
                    return;
                }
            }

            Console.WriteLine("Invalid Employee Id");
        }

        private Employee? SearchEmployeeById(int id)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    return employees[i];
                }
            }

            return null;
        }

        private Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the type of employee");
            string type = Console.ReadLine();

            if (type == "Permanent")
                employee = new PermanentEmployee();
            else if (type == "Contract")
                employee = new ContractEmployee();

            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        private void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}