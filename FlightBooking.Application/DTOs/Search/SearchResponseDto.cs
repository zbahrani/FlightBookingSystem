using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.DTOs.Search
{
    public class SearchResponseDto
    {
        public bool Success { get; set; }
        public List<FlightOptionDto> flights { get; set; }
    }
}
