using System;
using BusBookingSystem.BLL;
using BusBookingSystem.DAL;

namespace BusBookingSystem
{
    class AdminBookingManagement
    {
        private static readonly BookingService _bookingService = new BookingService(new BookingRepository());

        private static void BookTicket()
        {
            // Implement logic to collect booking details from the user
            // and call the corresponding service method from _bookingService
        }

        private static void CancelTicket()
        {
            // Implement logic to collect booking ID from the user
            // and call the corresponding service method from _bookingService
        }

        private static void ViewBookingHistory()
        {
            // Implement logic to retrieve booking history for the user
            // and display it to the user
        }
    }
}
