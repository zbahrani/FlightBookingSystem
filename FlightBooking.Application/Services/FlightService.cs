using FlightBookingApplication.Common;
using FlightBookingApplication.DTOs.Search;
using FlightBookingApplication.Interfaces;
using FlightBookingApplication.Validators;
using FlightBookingDomain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Services
{
    public class FlightService : IFlightSearchService
    {
        private readonly IValidator<SearchRequestDto> _validator;
        private readonly IAirtourHttpClientService _airtour;

        public FlightService(IValidator<SearchRequestDto> validator, IAirtourHttpClientService airtour)
        {
            _validator = validator;
            _airtour = airtour;
        }

        public async Task<Result<SearchResponseDto>> SearchFlightsAsync(SearchRequestDto request, CancellationToken ct = default)
        {
            var Validation = await _validator.ValidateAsync(request, ct);
            if (!Validation.IsValid)
            {    throw new CustomValidationException(Validation.Errors.Select(e => e.ErrorMessage));
                }
            var external = await _airtour.SearchAvailabilityAsync(request, ct);

            var dto = new SearchResponseDto
            {
                Success = true,
                Flights = external.Select(f => new FlightOptionDto
                {
                    FlightNumber = f.FlightNumber,
                    Airline = f.Airline,
                    Origin = f.Origin,
                    Destination = f.Destination,
                    Departure = f.Departure,
                    Arrival = f.Arrival,
                    TotalPrice = f.TotalPrice
                }).ToList()
            };

            return Result<SearchResponseDto>.Success(dto);


        }
    }
}
