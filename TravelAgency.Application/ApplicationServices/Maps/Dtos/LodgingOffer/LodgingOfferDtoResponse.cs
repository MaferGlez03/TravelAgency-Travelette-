using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer
{
    public class LodgingOfferDtoResponse
    {
        public int LodgingOfferId { get; set; } = 0;
        public string Description { get; set; }
        public double Price { get; set; }
        public HotelDto hotelDto {get; set;}
    }
}