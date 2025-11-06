using FlightBookingApplication.DTOs.Issue;
using FluentValidation;


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
