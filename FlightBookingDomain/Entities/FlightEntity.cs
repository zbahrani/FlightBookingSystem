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
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Airline { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public CityEnum Origin { get; set; }
        public CityEnum Destination { get; set; }
        
    }
}
