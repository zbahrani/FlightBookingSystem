using FlightBookingApplication.Common;
using FlightBookingApplication.DTOs.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Interfaces
{
    public interface IFlightBookingService
    {
        Task<Result<BookResponseDto>> BookingFlightAsync (BookRequestDto request, CancellationToken ct = default);
    }
}
