using FlightBookingApplication.DTOs.Booking;
using FlightBookingApplication.DTOs.Issue;
using FlightBookingApplication.DTOs.Search;

namespace FlightBookingApplication.Interfaces
{
    public interface IAirtourHttpClientService
    {
        Task<List<FlightOptionDto>> SearchAvailabilityAsync(SearchRequestDto request, CancellationToken ct = default);
        Task<BookResponseDto> BookAsync(BookRequestDto request, CancellationToken ct = default);
        Task<IssueResponseDto> IssueAsync(IssueRequestDto request, CancellationToken ct = default); 
    }
}
