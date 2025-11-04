using FlightBookingApplication.Common;
using FlightBookingApplication.DTOs.Search;
using FlightBookingApplication.Interfaces;
using FlightBookingDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Services
{
    public class FlightService : IFlightSearchService
    {
        public FlightService()
        {
        }

        public Task<Result<SearchResponseDto>> SearchFlightsAsync(SearchRequestDto request, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
