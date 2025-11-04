using FlightBookingDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDomain.Entities
{
    public class PassengerEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PassengerTypeEnum Type { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
