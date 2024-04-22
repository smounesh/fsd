using System;
using System.Collections.Generic;
using BusBookingSystem.DAL;

namespace BusBookingSystem.BLL
{
    public class BusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public void AddBus(Bus bus)
        {
            _busRepository.AddBus(bus);
            Console.WriteLine("Bus added successfully!");
        }

        public void UpdateBus(int busId, Bus updatedBus)
        {
            if (BusExists(busId))
            {
                _busRepository.UpdateBus(busId, updatedBus);
                Console.WriteLine("Bus updated successfully!");
            }
            else
            {
                Console.WriteLine($"Bus with ID {busId} does not exist.");
            }
        }

        public void RemoveBus(int busId)
        {
            if (BusExists(busId))
            {
                _busRepository.RemoveBus(busId);
                Console.WriteLine("Bus removed successfully!");
            }
            else
            {
                Console.WriteLine($"Bus with ID {busId} does not exist.");
            }
        }

        public bool BusExists(int busId)
        {
            return _busRepository.BusExists(busId);
        }

        public void ViewBusSchedule()
        {
            IEnumerable<Bus> buses = _busRepository.GetAllBuses();
            Console.WriteLine("Bus Schedule:");
            foreach (var bus in buses)
            {
                Console.WriteLine($"ID: {bus.Id}, Origin: {bus.Origin}, Destination: {bus.Destination}, Departure Time: {bus.DepartureTime}, Available Seats: {bus.AvailableSeats}");
            }
        }
    }
}
