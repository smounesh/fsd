// Program.cs
using ClinicManagement.BLL;
using ClinicManagement.DAL;
using System;

namespace ClinicManagement.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // You can implement UI logic here, such as displaying forms, handling user inputs, etc.
            Console.WriteLine("Clinic Management System");

            // Example of using BLL and DAL
            var doctorManager = new DoctorManager(new DoctorRepository());
            var doctors = doctorManager.GetAllDoctors();

            foreach (var doctor in doctors)
            {
                Console.WriteLine($"Doctor ID: {doctor.Id}, Name: {doctor.Name}");
            }
        }
    }
}
