namespace BusBookingSystem.DAL
{
    public class Bus
    {
        public int Id { get; set; }
        public string Origin { get; set; } = "";
        public string Destination { get; set; } = "";
        public string DepartureTime { get; set; } = "";
        public int AvailableSeats { get; set; }
    }
}
