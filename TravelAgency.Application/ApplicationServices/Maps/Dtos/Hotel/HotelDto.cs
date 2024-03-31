using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel
{
    public class HotelDto
    {
        public int Id {get; set;} = 0;
        public string Name {get; set;} = null!;
        public string Category{get; set;} = null!;
        public string Address {get; set;} = null!;
    }
}