using FlightBookingApplication.Common;
using FlightBookingApplication.DTOs.Search;
using FlightBookingApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IFlightSearchService _service;

        public SearchController(IFlightSearchService service)
        {
            _service = service;
        }

        [HttpPost("flights")]
        public async Task<IActionResult> Search([FromBody] SearchRequestDto request, CancellationToken ct)
        {
            try
            {
                var result = await _service.SearchFlightsAsync(request, ct);
                if (!result.IsSuccess)
                    return BadRequest(new { error = result.Massage });

                return Ok(result.Data);
            }
            catch (CustomValidationException vex)
            {
                return BadRequest(new { errors = vex.Errors });
            }
        }

    }   
}   
