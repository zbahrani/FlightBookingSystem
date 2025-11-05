using FlightBookingApplication.DTOs.Issue;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Validators
{
    public class IssueRequestValidator : AbstractValidator<IssueRequestDto>
    {
        public IssueRequestValidator() 
        {
            RuleFor(x => x.BookingReference).NotEmpty().WithMessage("کد رزرو الزامی است.");
        }
    }
}
