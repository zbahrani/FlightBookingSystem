using FlightBookingApplication.DTOs.Search;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Validators
{
    public class SearchRequestValidator : AbstractValidator<SearchRequestDto>
    {
        public SearchRequestValidator() 
        {
            RuleFor(x => x.Origin).NotEmpty().WithMessage("مبدا الزامی است.");
            RuleFor(x => x.Destination).NotEmpty().WithMessage("مقصد الزامی است.")
                .NotEqual(x => x.Origin).WithMessage("مبدا و مقصد نباید یکسان باشند.");


        }
    }
}
