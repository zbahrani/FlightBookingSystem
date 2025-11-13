using FlightBookingDomain.Enums;

namespace FlightBookingDomain.Entities
{
    public class BookingEntity : BaseEntity
    {
        public string FlightNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<PassengerEntity> Passengers { get; set; }
        public decimal TotalAmount { get; set; }
        public BookingStatusEnum BookingStatus { get; set; }
    }
}
