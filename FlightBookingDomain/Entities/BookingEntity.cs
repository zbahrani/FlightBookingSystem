using FlightBookingDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDomain.Entities
{
    public class BookingEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FlightNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<PassengerEntity> Passengers { get; set; }
        public decimal TotalAmount { get; set; }
        public BookingStatusEnum BookingStatus { get; set; }
    }
}
