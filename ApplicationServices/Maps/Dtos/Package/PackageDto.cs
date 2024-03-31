using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.Package
{
    public class PackageDto
    {
        public int Id {get; set;} = 0;
        public string Description {get; set;}
        public double Price{get; set;}
        public int Capacity { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AgencyID { get; set; }
        public List<FacilityDto> facilityDtos { get; set; }
    }
}