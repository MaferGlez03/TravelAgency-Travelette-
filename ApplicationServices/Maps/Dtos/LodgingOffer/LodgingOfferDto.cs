using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer
{
    public class LodgingOfferDto
    {
        public int Id { get; set; } = 0;
        public int HotelId { get; set; }
       
        public string Description { get; set; }
        public double Price { get; set; }
        
    }
}