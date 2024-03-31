using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel
{
    public class HotelResponseDto:HotelDto
    {
        public List<LodgingOfferDto> lodgingOffers {get;set;} = new List<LodgingOfferDto>();
    }
}