
namespace FlightBookingApplication.DTOs.Booking
{
    public class BookResponseDto
    {
        public bool Success { get; set; }
        public string? BookingReference { get; set; } 
        public decimal TotalAmount { get; set; }
        public string? Message { get; set; }
    }
}
