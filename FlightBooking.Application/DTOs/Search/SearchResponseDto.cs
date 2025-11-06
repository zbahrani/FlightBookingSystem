namespace FlightBookingApplication.DTOs.Search
{
    public class SearchResponseDto
    {
        public bool Success { get; set; }
        public List<FlightOptionDto> Flights { get; set; } = new();
    }
}
