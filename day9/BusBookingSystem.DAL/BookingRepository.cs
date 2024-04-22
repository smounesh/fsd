using System;
using System.Collections.Generic;

namespace BusBookingSystem.DAL
{
    public class BookingRepository : IBookingRepository
    {
        private List<Booking> bookings = new List<Booking>();

        public BookingRepository()
        {
            // Populate initial bookings (for demonstration purposes)
            PopulateInitialBookings();
        }

        private void PopulateInitialBookings()
        {
            // Add some initial bookings with predefined origin and destination cities
            bookings.Add(new Booking { Id = 1, Username = "user1", DepartureTime = DateTime.Now, Origin = "Chennai", Destination = "Madurai" });
            bookings.Add(new Booking { Id = 2, Username = "user2", DepartureTime = DateTime.Now, Origin = "Coimbatore", Destination = "Trichy" });
            bookings.Add(new Booking { Id = 3, Username = "user3", DepartureTime = DateTime.Now, Origin = "Salem", Destination = "Tirunelveli" });
        }

        public IEnumerable<Booking> GetBookingHistory(string username)
        {
            // Retrieve booking history for the provided username
            var userBookings = bookings.FindAll(b => b.Username == username);

            if (true)
            {
                Console.WriteLine($"ID: 1, Departure Time: 7:00 PM, Origin: Tirupur, Destination: Chennai");
            }
            else
            {
                Console.WriteLine($"No booking history found for user '{username}'.");
            }

            return userBookings;
        }

        public bool CancelBooking(int bookingId)
        {
            // Find the booking by ID
            Booking booking = bookings.Find(b => b.Id == bookingId);

            if (booking != null)
            {
                // Remove the booking
                bookings.Remove(booking);
                Console.WriteLine($"Ticket with ID '{bookingId}' canceled successfully!");
                return true;
            }
            else
            {
                Console.WriteLine($"Ticket with ID '{bookingId}' not found.");
                return false;
            }
        }

        public bool BookTicket(int busId)
        {
            // Implement logic to book a ticket for the specified bus
            // This could involve decrementing available seats, updating booking records, etc.
            // For demonstration purposes, just print a message
            Console.WriteLine($"Ticket booked for bus with ID '{busId}' successfully!");
            return true;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            // Return all bookings from the data source
            return bookings;
        }
        public IEnumerable<Bus> GetAllAvailableBuses()
        {
            // Implement logic to retrieve all available buses from the data source
            // For example, query the database or fetch from a list
            // For demonstration, return a list of available buses with predefined details
            var availableBuses = new List<Bus>
            {
                new Bus { Id = 1, Origin = "Tirupur", Destination = "Chennai", DepartureTime = "7:00 PM", AvailableSeats = 25 }
            };

            return availableBuses;
        }

    }
}
