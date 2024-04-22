using System;
using System.Collections.Generic;

namespace BusBookingSystem.DAL
{
    public class BusRepository : IBusRepository
    {
        private readonly List<Bus> _buses;

        public BusRepository()
        {
            _buses = new List<Bus>();
        }

        public void AddBus(Bus bus)
        {
            _buses.Add(bus);
        }

        public void UpdateBus(int busId, Bus updatedBus)
        {
            var index = _buses.FindIndex(b => b.Id == busId);
            if (index != -1)
            {
                _buses[index] = updatedBus;
            }
        }

        public void RemoveBus(int busId)
        {
            var busToRemove = _buses.Find(b => b.Id == busId);
            if (busToRemove != null)
            {
                _buses.Remove(busToRemove);
            }
        }

        public IEnumerable<Bus> GetAllBuses()
        {
            return _buses;
        }

        public bool BusExists(int busId)
        {
            return _buses.Exists(b => b.Id == busId);
        }
    }
}
