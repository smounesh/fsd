using System;
using System.Collections.Generic;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Add other properties as needed
}

public class EmployeeManagement
{
    private List<Employee> employees;

    public EmployeeManagement()
    {
        employees = new List<Employee>();
    }

    // Method to create an employee
    public void CreateEmployee(int id, string name)
    {
        Employee emp = new Employee { Id = id, Name = name };
        employees.Add(emp);
        Console.WriteLine("Employee created successfully.");
        PrintEmployee(emp);
    }

    // Method to print an employee
    public void PrintEmployee(Employee employee)
    {
        Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}");
    }

    // Method to print all employees
    public void PrintAllEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }
        Console.WriteLine("All Employees:");
        foreach (Employee emp in employees)
        {
            PrintEmployee(emp);
        }
    }

    // Method to search for employees by name
    public void SearchEmployee(string searchTerm)
    {
        List<Employee> searchResults = employees.FindAll(emp => emp.Name.Contains(searchTerm));
        if (searchResults.Count == 0)
        {
            Console.WriteLine("No employees found matching the search term.");
            return;
        }
        Console.WriteLine("Search Results:");
        foreach (Employee emp in searchResults)
        {
            PrintEmployee(emp);
        }
    }

    // Method to update employee name
    public void UpdateEmployeeName(int id, string newName)
    {
        Employee emp = employees.Find(e => e.Id == id);
        if (emp == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }
        emp.Name = newName;
        Console.WriteLine("Employee name updated successfully.");
        PrintEmployee(emp);
    }

    // Method to delete an employee
    public void DeleteEmployee(int id)
    {
        Employee emp = employees.Find(e => e.Id == id);
        if (emp == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }
        employees.Remove(emp);
        Console.WriteLine("Employee deleted successfully.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeManagement empManagement = new EmployeeManagement();
        int choice;
        do
        {
            Console.WriteLine("1. Create Employee");
            Console.WriteLine("2. Print All Employees");
            Console.WriteLine("3. Search Employees");
            Console.WriteLine("4. Update Employee Name");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice:");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Employee ID:");
                    int id;
                    if (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Invalid ID. Please enter a number.");
                        break;
                    }
                    Console.WriteLine("Enter Employee Name:");
                    string name = Console.ReadLine();
                    empManagement.CreateEmployee(id, name);
                    break;
                case 2:
                    empManagement.PrintAllEmployees();
                    break;
                case 3:
                    Console.WriteLine("Enter Search Term:");
                    string searchTerm = Console.ReadLine();
                    empManagement.SearchEmployee(searchTerm);
                    break;
                case 4:
                    Console.WriteLine("Enter Employee ID:");
                    int updateId;
                    if (!int.TryParse(Console.ReadLine(), out updateId))
                    {
                        Console.WriteLine("Invalid ID. Please enter a number.");
                        break;
                    }
                    Console.WriteLine("Enter New Employee Name:");
                    string newName = Console.ReadLine();
                    empManagement.UpdateEmployeeName(updateId, newName);
                    break;
                case 5:
                    Console.WriteLine("Enter Employee ID to Delete:");
                    int deleteId;
                    if (!int.TryParse(Console.ReadLine(), out deleteId))
                    {
                        Console.WriteLine("Invalid ID. Please enter a number.");
                        break;
                    }
                    empManagement.DeleteEmployee(deleteId);
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid menu option.");
                    break;
            }
        } while (choice != 6);
    }
}
