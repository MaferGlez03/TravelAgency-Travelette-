using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility
{
    public class FacilityDto
    {
        public string Name {get; set;} = null!; //Must be NON-NULL!!!
        public int Id {get; set;}  //Must be NON-NULL!!!
    }
}