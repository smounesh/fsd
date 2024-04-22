using System;

namespace BusBookingSystem.DAL
{
    public class Booking
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public DateTime DepartureTime { get; set; }
        public string Origin { get; set; } = "";
        public string Destination { get; set; } = "";
    }
}
