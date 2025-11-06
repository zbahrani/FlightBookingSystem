using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
