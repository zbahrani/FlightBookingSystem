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
        
        public FlightService(IValidator<SearchRequestDto> validator)
        {
            _validator = validator;
        }

        public async Task<Result<SearchResponseDto>> SearchFlightsAsync(SearchRequestDto request, CancellationToken ct = default)
        {
            var Validation = await _validator.ValidateAsync(request, ct);
            if (!Validation.IsValid)
            {
                throw new CustomValidationException(Validation.Errors.Select(e => e.ErrorMessage));
            }
            return Result<SearchResponseDto>.Success();
        }
    }
}
