
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
