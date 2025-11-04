using FlightBookingApplication.Common;
using FlightBookingApplication.DTOs.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Interfaces
{
    public interface IIssueTicketService
    {
        Task<Result<IssueResponseDto>> IssueTicketAsync(IssueRequestDto request, CancellationToken ct = default);
    }
}
