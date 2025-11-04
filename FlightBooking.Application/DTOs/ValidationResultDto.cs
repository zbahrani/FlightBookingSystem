using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Dto
{
    public class ValidationResultDto
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new();
        public string Message => IsValid ? "معتبر" : string.Join(" | ", Errors);

        public static ValidationResultDto Success() => new() { IsValid = true };
        public static ValidationResultDto Failure(List<string> errors) => new() { IsValid = false, Errors = errors };

    }
}
