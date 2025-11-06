using FlightBookingApplication.Interfaces;
using FlightBookingApplication.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace FlightBookingApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IFlightSearchService, FlightSearchService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
