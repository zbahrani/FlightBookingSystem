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
            RuleFor(x => x.DepartureDate).GreaterThanOrEqualTo(DateTime.Today).WithMessage("تاریخ رفت باید امروز یا بعد از امروز باشد.");
            RuleFor(x => x.ReturnDate).GreaterThanOrEqualTo(x => x.DepartureDate)
                                      .When(x => x.ReturnDate.HasValue)
                                      .WithMessage("تاریخ برگشت باید بعد از تاریخ رفت باشد.");
            RuleFor(x => x.Adults + x.Children + x.Infants).GreaterThan(0).WithMessage("حداقل یک مسافر باید انتخاب شود.");
            

        }
    }
}
