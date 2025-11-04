using FlightBookingApplication.Interfaces;
using FlightBookingDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Services
{
    public class FlightService : IFlightService
    {
        public FlightService()
        {
        }

        public Task<List<FlightEntity>> SearchFlightsAsync(FlightSearchEntity search)
        {
            throw new NotImplementedException();
        }
    }
}
