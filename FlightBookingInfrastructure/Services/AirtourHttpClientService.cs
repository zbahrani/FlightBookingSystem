using FlightBookingApplication.DTOs.Booking;
using FlightBookingApplication.DTOs.Issue;
using FlightBookingApplication.DTOs.Search;
using FlightBookingApplication.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightBookingInfrastructure.Services
{
    public class AirtourHttpClientService : IAirtourHttpClientService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;
        private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

        public AirtourHttpClientService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        //public async Task<BookResponseDto> BookAsync(BookRequestDto request, CancellationToken ct = default)
        //{
        //    var payload = new
        //    {
        //        POS = new { UserName = _config["AirtourApi:Username"], Password = _config["AirtourApi:Password"] },
        //        AirItinerary = new
        //        {
        //            OriginDestinationOptions = new[] {
        //            new { FlightSegment = new[] { new { FlightNumber = request.FlightNumber } } }
        //        }
        //        },
        //        PriceInfo = new { ItinTotalFare = new { TotalFare = new { Amount = 0 } } },
        //        TravelerInfo = request.passengers.Select(p => new {
        //            PersonName = new { GivenName = p.FirstName, Surname = p.LastName },
        //            BirthDate = p.BirthDate.ToString("yyyy-MM-dd"),
        //            PassengerTypeCode = p.PassengerType
        //        }).ToArray()
        //    };
        //    var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
        //    var resp = await _http.PostAsync("/Book", content, ct);

        //    if (!resp.IsSuccessStatusCode)
        //    {
                
        //        var body = await resp.Content.ReadAsStringAsync(ct);
        //        return new BookResponseDto { Success = false, BookingReference = null, TotalAmount = 0, Message = $"Airtour Book API error: {resp.StatusCode} - {body}" };
        //    }
        //    var raw = await resp.Content.ReadAsStringAsync(ct);
        //    try
        //    {
        //        var doc = JsonDocument.Parse(raw);
 
        //        var bookingRef = doc.RootElement.GetProperty("AirReservation").GetProperty("RecordLocator").GetString();
        //        return new BookResponseDto { Success = true, BookingReference = bookingRef ?? Guid.NewGuid().ToString(), TotalAmount = 0, Message = "Booked via Airtour" };
        //    }
        //    catch
        //    {
               
        //        return new BookResponseDto { Success = true, BookingReference = Guid.NewGuid().ToString(), TotalAmount = 0, Message = "Booked (mock)" };
        //    }
        //}

        //public Task<IssueResponseDto> IssueAsync(IssueRequestDto request, CancellationToken ct = default)
        //{
        //    throw new NotImplementedException();
        //}

        
        public async Task<List<FlightOptionDto>> SearchAvailabilityAsync(SearchRequestDto request, CancellationToken ct = default)
        {
            var baseUrl = _config["AirtourApi:BaseUrl"];
            var url = $"{baseUrl}/Search";

            // 🔹 ارسال درخواست به API ایرتور
            var response = await _http.PostAsJsonAsync(url, request, ct);
            response.EnsureSuccessStatusCode();

            // 🔹 دسیالایز کردن خروجی به DTOهای خودت
            var result = await response.Content.ReadFromJsonAsync<List<FlightOptionDto>>(cancellationToken: ct);

            return result ?? new List<FlightOptionDto>();
        }
    }
}
