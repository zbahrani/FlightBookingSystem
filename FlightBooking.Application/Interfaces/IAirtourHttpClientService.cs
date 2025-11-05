using FlightBookingApplication.DTOs.Booking;
using FlightBookingApplication.DTOs.Issue;
using FlightBookingApplication.DTOs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Interfaces
{
    public interface IAirtourHttpClientService
    {
        Task<List<FlightOptionDto>> SearchAvailabilityAsync(SearchRequestDto request, CancellationToken ct = default);
        //Task<BookResponseDto> BookAsync(BookRequestDto request, CancellationToken ct = default);
        //Task<IssueResponseDto> IssueAsync(IssueRequestDto request, CancellationToken ct = default); 
    }
}
