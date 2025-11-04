using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.DTOs.Issue
{
    public class IssueResponseDto
    {
        public bool Success { get; set; }
        public string TicketNumber { get; set; } 
        public string Message { get; set; }
    }
}
