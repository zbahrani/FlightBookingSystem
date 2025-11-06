using FlightBookingApplication.Common;
using FlightBookingApplication.DTOs.Issue;

namespace FlightBookingApplication.Interfaces
{
    public interface IIssueTicketService
    {
        Task<Result<IssueResponseDto>> IssueTicketAsync(IssueRequestDto request, CancellationToken ct = default);
    }
}
