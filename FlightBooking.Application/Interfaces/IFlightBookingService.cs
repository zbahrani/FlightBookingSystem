using FlightBookingApplication.Common;
using FlightBookingApplication.DTOs.Booking;


namespace FlightBookingApplication.Interfaces
{
    public interface IFlightBookingService
    {
        Task<Result<BookResponseDto>> BookingFlightAsync (BookRequestDto request, CancellationToken ct = default);
    }
}
