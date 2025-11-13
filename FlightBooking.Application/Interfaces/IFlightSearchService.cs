using FlightBookingApplication.Common;
using FlightBookingApplication.DTOs.Search;

namespace FlightBookingApplication.Interfaces
{
    public interface IFlightSearchService
    {
        Task<Result<SearchResponseDto>> SearchFlightsAsync(SearchRequestDto request, CancellationToken ct = default);

    }
}
