using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Common
{
    public class CustomValidationException : Exception
    {
        public IEnumerable<string> Errors { get; }
        public CustomValidationException(IEnumerable<string> errors) : base("Validation failed")
        {
            Errors = errors;
        }
    }
}
