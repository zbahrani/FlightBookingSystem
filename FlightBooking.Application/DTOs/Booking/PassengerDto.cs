using FlightBookingDomain.Enums;

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
