using System.Collections.Generic;

namespace BusBookingSystem.DAL
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetBookingHistory(string username);
        bool CancelBooking(int bookingId);
        IEnumerable<Bus> GetAllAvailableBuses();
        bool BookTicket(int busId);
    }
}
