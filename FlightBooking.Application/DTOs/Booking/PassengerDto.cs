using FlightBookingDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.DTOs.Booking
{
    public class PassengerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PassengerTypeEnum PassengerType { get; set; } = PassengerTypeEnum.Adult;
        public DateTime BirthDate { get; set; }
    }
}
