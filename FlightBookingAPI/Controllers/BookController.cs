using FlightBookingApplication.DTOs.Booking;
using FlightBookingApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IAirtourHttpClientService _airtourService;

        public BookController(IAirtourHttpClientService airtourService)
        {
            _airtourService = airtourService;
        }
        [HttpPost("booking")]
        public async Task<IActionResult> Book ([FromBody] BookRequestDto request, CancellationToken ct)
        {
            if (request == null)
                return BadRequest(new { error = "درخواست نامعتبر است." });

            try
            {
                var result = await _airtourService.BookAsync(request, ct);

                if (!result.Success)
                    return BadRequest(new { error = result.Message });

                return Ok(new
                {
                    success = result.Success,
                    bookingReference = result.BookingReference,
                    totalAmount = result.TotalAmount,
                    message = result.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"خطا در رزرو پرواز: {ex.Message}" });
            }
        }
    }
}
