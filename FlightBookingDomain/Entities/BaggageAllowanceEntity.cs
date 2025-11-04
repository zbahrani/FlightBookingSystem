using FlightBookingDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDomain.Entities
{
    public class BaggageAllowanceEntity
    {
        public PassengerTypeEnum PassengerType { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
    }
}
