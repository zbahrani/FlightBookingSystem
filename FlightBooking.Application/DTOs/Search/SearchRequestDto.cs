using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.DTOs.Search
{
    public class SearchRequestDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Adults { get; set; } = 1;
        public int Children { get; set; } = 0;
        public int Infants { get; set; } = 0;
    }
}
