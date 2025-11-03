using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDomain.Entities
{
    public class BookingRequestEntity
    {
        public FlightSearchEntity SearchCriteria { get; set; }
        public List<PassengerEntity> Passengers { get; set; }
        public string SelectedFlightId { get; set; }
        public string SelectedReturnFlightId { get; set; }
    }
}
