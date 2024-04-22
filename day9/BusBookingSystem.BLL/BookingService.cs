using System.Collections.Generic;
using BusBookingSystem.DAL;

namespace BusBookingSystem.BLL
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }

        public IEnumerable<Booking> GetBookingHistory(string username)
        {
            return _bookingRepository.GetBookingHistory(username);
        }

        public bool CancelBooking(int bookingId)
        {
            return _bookingRepository.CancelBooking(bookingId);
        }

        public IEnumerable<Bus> GetAllAvailableBuses()
        {
            return _bookingRepository.GetAllAvailableBuses();
        }

        public bool BookTicket(int busId)
        {
            return _bookingRepository.BookTicket(busId);
        }
    }
}
