using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Infrastructure.DataAccess.Filters
{
    public class AgencyFilters
    {
        public string AgencyName { get; set; } = string.Empty;
        public List<string> AgencyNameList { get; set; } =new();
        public string Address { get; set; } = string.Empty;
        public int HotelId { get; set; }
        public DateFilter? Dates { get; set; }

        public bool IncludeOffers { get; set; }
        public bool IncludeOfferWithHotel { get; set; }
    }

    public class DateFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}