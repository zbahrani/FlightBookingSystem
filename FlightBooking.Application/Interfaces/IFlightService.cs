using FlightBookingApplication.Common;
using FlightBookingApplication.DTOs.Search;
using FlightBookingDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Interfaces
{
    public interface IFlightSearchService
    {
        Task<Result<SearchResponseDto>> SearchFlightsAsync(SearchRequestDto request, CancellationToken ct = default);

    }
}
