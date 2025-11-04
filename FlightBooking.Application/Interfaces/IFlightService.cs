using FlightBookingDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApplication.Interfaces
{
    public interface IFlightService
    {
        Task<List<FlightEntity>> SearchFlightsAsync(FlightSearchEntity search);
        
    }
}
