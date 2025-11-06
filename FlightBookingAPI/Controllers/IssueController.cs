using FlightBookingApplication.DTOs.Issue;
using FlightBookingApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IAirtourHttpClientService _airtourService;

        public IssueController(IAirtourHttpClientService airtourService)
        {
            _airtourService = airtourService;
        }

        
        [HttpPost]
        public async Task<IActionResult> Issue([FromBody] IssueRequestDto request, CancellationToken ct)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.BookingReference))
                return BadRequest(new { error = "کد رزرو الزامی است." });

            try
            {
                var result = await _airtourService.IssueAsync(request, ct);

                if (!result.Success)
                    return BadRequest(new { error = result.Message });

                return Ok(new
                {
                    success = result.Success,
                    ticketNumber = result.TicketNumber,
                    message = result.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"خطا در صدور بلیت: {ex.Message}" });
            }
        }
    }
}
