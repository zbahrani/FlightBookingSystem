using FlightBookingDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDomain.Entities
{
    public class FlightEntity
    {
        public string FlightId { get; set; }
        public string Airline { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "IRR";
        public CityEnum Origin { get; set; }
        public CityEnum Destination { get; set; }
        public int AvailableSeats { get; set; }
        public string AircraftType { get; set; }
        public TimeSpan Duration { get; set; }
        public string DepartureTerminal { get; set; }
        public string ArrivalTerminal { get; set; }
        public List<BaggageAllowanceEntity> BaggageAllowances { get; set; } = new();
    }
}
