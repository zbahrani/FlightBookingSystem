using FlightBookingApplication.DTOs.Booking;
using FlightBookingDomain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Validators
{
    public class BookRequestValidator : AbstractValidator<BookRequestDto>
    {
        public BookRequestValidator() 
        {
            RuleFor(x => x.FlightNumber).NotEmpty().WithMessage("شماره پرواز الزامی است.");
            RuleFor(x => x.passengers).NotEmpty().WithMessage("لیست مسافران خالی است.");
            RuleForEach(x => x.passengers).ChildRules(p =>
            {
                p.RuleFor(pp => pp.FirstName).NotEmpty().WithMessage("نام مسافر الزامی است.");
                p.RuleFor(pp => pp.LastName).NotEmpty().WithMessage("نام خانوادگی مسافر الزامی است.");
                p.RuleFor(pp => pp.PassengerType).Must(t => Enum.IsDefined(typeof(PassengerTypeEnum), t))
                    .WithMessage("نوع مسافر باید یکی از مقادیر معتبر Enum باشد.");
            });
        }
    }
}
