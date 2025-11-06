using FlightBookingDomain.Enums;

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
