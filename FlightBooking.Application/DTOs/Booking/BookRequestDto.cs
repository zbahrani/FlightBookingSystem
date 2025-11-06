using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.DTOs.Booking
{
    public class BookRequestDto
    {
        public string FlightNumber { get; set; }
        public List<PassengerDto> passengers { get; set; } = new();
        public decimal Price { get; set; }
    }
}
