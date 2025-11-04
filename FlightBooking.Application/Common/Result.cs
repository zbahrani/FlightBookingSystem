using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public string? Massage { get; }
        public T? Data {  get; }

        private Result(bool success, T? data = default, string? massage = null)
        {
            IsSuccess = success;
            Data = data;
            Massage = massage;
           
        }
        public static Result<T> Success(T data, string? message = null) => new(true, data, message);
        public static Result<T> Failure(string message) => new(false, default, message);
    }
}
