using System;
using BusBookingSystem.BLL;
using BusBookingSystem.DAL;

namespace BusBookingSystem
{
    class BusManagement
    {
        private static readonly BusService _busService = new BusService(new BusRepository());

        public static void HandleBusManagementOption(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Adding Bus...");
                    AddBus();
                    break;
                case 2:
                    Console.WriteLine("Updating Bus...");
                    UpdateBus();
                    break;
                case 3:
                    Console.WriteLine("Removing Bus...");
                    RemoveBus();
                    break;
                case 4:
                    Console.WriteLine("Viewing Bus Schedule...");
                    ViewBusSchedule();
                    break;
                case 5:
                    Program.Logout();
                    break;
                case 6:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void Exit()
        {
            // Implement Exit functionality
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }

        public static void PrintBusManagementMenu()
        {
            Console.WriteLine("Bus Management Menu:");
            Console.WriteLine("1. Add Bus");
            Console.WriteLine("2. Update Bus");
            Console.WriteLine("3. Remove Bus");
            Console.WriteLine("4. View Bus Schedule");
            Console.WriteLine("5. Logout");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
        }

        public static int GetMenuOption()
        {
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    return option;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static void AddBus()
        {
            // Collect bus details from the user
            Console.Write("Enter Origin: ");
            string origin = Console.ReadLine();

            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter Departure Time: ");
            string departureTime = Console.ReadLine();

            Console.Write("Enter Available Seats: ");
            if (int.TryParse(Console.ReadLine(), out int availableSeats))
            {
                // Create a new bus object
                Bus bus = new Bus
                {
                    Origin = origin,
                    Destination = destination,
                    DepartureTime = departureTime,
                    AvailableSeats = availableSeats
                };

                // Call BLL method to add the bus
                _busService.AddBus(bus);
                Console.WriteLine("Bus added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid input for available seats. Please enter a number.");
            }
        }

        private static void UpdateBus()
        {
            // Collect bus ID from the user
            Console.Write("Enter Bus ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int busId))
            {
                // Check if the bus exists
                if (_busService.BusExists(busId))
                {
                    // Collect updated bus details from the user
                    Console.Write("Enter Origin: ");
                    string origin = Console.ReadLine();

                    Console.Write("Enter Destination: ");
                    string destination = Console.ReadLine();

                    Console.Write("Enter Departure Time: ");
                    string departureTime = Console.ReadLine();

                    Console.Write("Enter Available Seats: ");
                    if (int.TryParse(Console.ReadLine(), out int availableSeats))
                    {
                        // Create a new bus object with updated details
                        Bus updatedBus = new Bus
                        {
                            Id = busId,
                            Origin = origin,
                            Destination = destination,
                            DepartureTime = departureTime,
                            AvailableSeats = availableSeats
                        };

                        // Call BLL method to update the bus
                        _busService.UpdateBus(busId, updatedBus);
                        Console.WriteLine("Bus updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for available seats. Please enter a number.");
                    }
                }
                else
                {
                    Console.WriteLine($"Bus with ID {busId} does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Bus ID. Please enter a number.");
            }
        }

        private static void RemoveBus()
        {
            // Collect bus ID from the user
            Console.Write("Enter Bus ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int busId))
            {
                // Check if the bus exists
                if (_busService.BusExists(busId))
                {
                    // Call BLL method to remove the bus
                    _busService.RemoveBus(busId);
                    Console.WriteLine("Bus removed successfully!");
                }
                else
                {
                    Console.WriteLine($"Bus with ID {busId} does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Bus ID. Please enter a number.");
            }
        }

        public static void ViewBusSchedule()
        {
            // Call BLL method to view the bus schedule
            _busService.ViewBusSchedule();
        }
    }
}
