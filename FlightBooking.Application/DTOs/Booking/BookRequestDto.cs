
namespace FlightBookingApplication.DTOs.Booking
{
    public class BookRequestDto
    {
        public string FlightNumber { get; set; }
        public List<PassengerDto> Passengers { get; set; } = new();
        public decimal Price { get; set; }
    }
}
