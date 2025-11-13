using FlightBookingDomain.Enums;


namespace FlightBookingDomain.Entities
{
    public class FlightEntity : BaseEntity
    {
        public string Airline { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public CityEnum Origin { get; set; }
        public CityEnum Destination { get; set; }
        
    }
}
