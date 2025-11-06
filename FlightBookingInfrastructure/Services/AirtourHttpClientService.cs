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

        public async Task<BookResponseDto> BookAsync(BookRequestDto request, CancellationToken ct = default)
        {
            var payload = new
            {
                POS = new
                {
                    UserName = _config["AirtourApi:Username"],
                    Password = _config["AirtourApi:Password"]
                },
                AirItinerary = new
                {
                    OriginDestinationOptions = new[]
            {
                new
                {
                    FlightSegment = new[]
                    {
                        new { FlightNumber = request.FlightNumber }
                    }
                }
            }
                },
                PriceInfo = new
                {
                    ItinTotalFare = new
                    {
                        TotalFare = new { Amount = request.Price }
                    }
                },
                TravelerInfo = request.passengers.Select(p => new
                {
                    PersonName = new { GivenName = p.FirstName, Surname = p.LastName },
                    BirthDate = p.BirthDate.ToString("yyyy-MM-dd"),
                    PassengerTypeCode = p.PassengerType.ToString()
                }).ToArray()
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            
            var baseUrl = _config["AirtourApi:BaseUrl"] ?? "http://apitest.airtour.faranegar.com";
            var resp = await _http.PostAsync($"{baseUrl}/Air_Book", content, ct);

            var raw = await resp.Content.ReadAsStringAsync(ct);

            if (!resp.IsSuccessStatusCode)
            {
                return new BookResponseDto
                {
                    Success = false,
                    BookingReference = null,
                    TotalAmount = 0,
                    Message = $"Airtour Book API error: {resp.StatusCode} - {raw}"
                };
            }

            try
            {
                using var doc = JsonDocument.Parse(raw);
                string? bookingRef = null;

                if (doc.RootElement.TryGetProperty("AirReservation", out var airRes) &&
                    airRes.TryGetProperty("RecordLocator", out var recordLocator))
                {
                    bookingRef = recordLocator.GetString();
                }

                return new BookResponseDto
                {
                    Success = true,
                    BookingReference = bookingRef ?? Guid.NewGuid().ToString(),
                    TotalAmount = request.Price,
                    Message = "Booked via Airtour"
                };
            }
            catch
            {
                return new BookResponseDto
                {
                    Success = true,
                    BookingReference = Guid.NewGuid().ToString(),
                    TotalAmount = request.Price,
                    Message = "Booked (mock)"
                };
            }
        }
        //public Task<IssueResponseDto> IssueAsync(IssueRequestDto request, CancellationToken ct = default)
        //{
        //    throw new NotImplementedException();
        //}


        public async Task<List<FlightOptionDto>> SearchAvailabilityAsync(SearchRequestDto request, CancellationToken ct = default)
        {
            var baseUrl = _config["AirtourApi:BaseUrl"];
            var url = $"{baseUrl}/Air_Available";


            var payload = new
            {
                POS = new
                {
                    UserName = _config["AirtourApi:Username"],
                    Password = _config["AirtourApi:Password"]
                },
                OriginDestinationInformation = new
                {
                    DepartureDateTime = request.DepartureDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                    ReturnDateTime = request.ReturnDate?.ToString("yyyy-MM-ddTHH:mm:ss"),
                    OriginLocation = request.Origin,
                    DestinationLocation = request.Destination
                },
                TravelerInfoSummary = new
                {
                    SeatsRequested = request.Adults + request.Children + request.Infants,
                    TravelerInformation = new
                    {
                        AirTravelerAvail = new object[]
               {
                    new { PassengerTypeQuantity = new { Code = "ADT", Quantity = request.Adults } },
                    new { PassengerTypeQuantity = new { Code = "CHD", Quantity = request.Children } },
                    new { PassengerTypeQuantity = new { Code = "INF", Quantity = request.Infants } }
               }
                    }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var resp = await _http.PostAsync(url, content, ct);
            resp.EnsureSuccessStatusCode();

            var body = await resp.Content.ReadAsStringAsync(ct);
            var doc = JsonDocument.Parse(body);

            var flights = new List<FlightOptionDto>();

            if (doc.RootElement.TryGetProperty("AirItinerary", out var itin) &&
                itin.TryGetProperty("OriginDestinationOptions", out var options))
            {
                foreach (var opt in options.EnumerateArray())
                {
                    if (opt.TryGetProperty("FlightSegment", out var segs))
                    {
                        foreach (var seg in segs.EnumerateArray())
                        {
                            flights.Add(new FlightOptionDto
                            {
                                FlightNumber = seg.GetProperty("FlightNumber").GetString() ?? "",
                                Airline = seg.GetProperty("Airline").GetString() ?? "",
                                Origin = seg.GetProperty("Origin").GetString() ?? "",
                                Destination = seg.GetProperty("Destination").GetString() ?? "",
                                Departure = DateTime.Parse(seg.GetProperty("DepartureDateTime").GetString() ?? ""),
                                Arrival = DateTime.Parse(seg.GetProperty("ArrivalDateTime").GetString() ?? ""),
                                TotalPrice = seg.GetProperty("Price").GetDecimal()
                            });
                        }
                    }
                }
            }

            return flights;
        }
    }
}
