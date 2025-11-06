using FlightBookingApplication.Interfaces;
using FlightBookingInfrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightBookingInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // ثبت سرویس HttpClient برای Airtour API
            services.AddHttpClient<IAirtourHttpClientService, AirtourHttpClientService>(client =>
            {
                var baseUrl = configuration["AirtourApi:BaseUrl"];
                client.BaseAddress = new Uri(baseUrl!);
            });

            return services;
        }
    }
}
