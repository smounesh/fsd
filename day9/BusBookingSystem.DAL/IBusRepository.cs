using System.Collections.Generic;

namespace BusBookingSystem.DAL
{
    public interface IBusRepository
    {
        void AddBus(Bus bus);
        void UpdateBus(int busId, Bus updatedBus);
        void RemoveBus(int busId);
        IEnumerable<Bus> GetAllBuses();
        bool BusExists(int busId);
    }
}
