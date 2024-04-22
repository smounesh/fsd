using System;
using System.Collections.Generic;
using System.Linq;
using BusBookingSystem.BLL;
using BusBookingSystem.DAL;

namespace BusBookingSystem
{
    class UserBookingManagement
    {
        private static readonly BookingService _bookingService = new BookingService(new BookingRepository());

        public static void ViewAllBookings()
        {
            // Get all bookings for the current user (replace "username" with the actual username)
            var bookings = _bookingService.GetBookingHistory("username");

            if (bookings.Any())
            {
                Console.WriteLine("All Bookings:");
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"ID: {booking.Id}, Username: {booking.Username}, Departure Time: {booking.DepartureTime}, Origin: {booking.Origin}, Destination: {booking.Destination}");
                }
            }
            else
            {
                Console.WriteLine("No bookings found.");
            }
        }

        public static void CancelTicket()
        {
            // Get all bookings for the current user (replace "username" with the actual username)
            var bookings = _bookingService.GetBookingHistory("username");

            if (bookings.Any())
            {
                Console.WriteLine("Choose the booking ID to cancel:");
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"ID: {booking.Id}, Username: {booking.Username}, Departure Time: {booking.DepartureTime}, Origin: {booking.Origin}, Destination: {booking.Destination}");
                }

                Console.Write("Enter Booking ID: ");
                if (int.TryParse(Console.ReadLine(), out int bookingId))
                {
                    // Call the CancelTicket method from the BookingService
                    _bookingService.CancelBooking(bookingId);
                    Console.WriteLine($"Booking with ID {bookingId} canceled successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid booking ID.");
                }
            }
            else
            {
                // Console.WriteLine("No bookings found to cancel.");
            }
        }

        public static void ViewBookingHistory()
        {
            // Get booking history for the current user (replace "username" with the actual username)
            var bookingHistory = _bookingService.GetBookingHistory("username");

            if (bookingHistory.Any())
            {
                Console.WriteLine("Booking History:");
                foreach (var booking in bookingHistory)
                {
                    Console.WriteLine($"Username: {booking.Username}, Departure Time: {booking.DepartureTime}, Origin: {booking.Origin}, Destination: {booking.Destination}");
                }
            }
            else
            {
                // Console.WriteLine("No booking history found.");
            }
        }

        public static void BookTicket()
        {
            var availableBuses = _bookingService.GetAllAvailableBuses();
            
            if (availableBuses.Any())
            {
                Console.WriteLine("Available Buses:");
                foreach (var bus in availableBuses)
                {
                    Console.WriteLine($"Bus ID: {bus.Id}, Origin: {bus.Origin}, Destination: {bus.Destination}, Departure Time: {bus.DepartureTime}, Available Seats: {bus.AvailableSeats}");
                }

                Console.Write("Enter Bus ID to book: ");
                if (int.TryParse(Console.ReadLine(), out int busId))
                {
                    // Call the BookTicket method from the BookingService
                    var result = _bookingService.BookTicket(busId);

                    if (result)
                    {
                        Console.WriteLine("Ticket booked successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to book ticket. Please try again later.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Bus ID.");
                }
            }
            else
            {
                Console.WriteLine("No available buses found.");
            }
        }
    }

}
