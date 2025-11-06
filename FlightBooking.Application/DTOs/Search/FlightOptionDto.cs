
namespace FlightBookingApplication.DTOs.Search
{
    public class FlightOptionDto
    {
        public string FlightNumber { get; set; } = default!;
        public string Airline {  get; set; } = default!;
        public string Origin { get; set; } = default!;
        public string Destination { get; set; } = default!;
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
