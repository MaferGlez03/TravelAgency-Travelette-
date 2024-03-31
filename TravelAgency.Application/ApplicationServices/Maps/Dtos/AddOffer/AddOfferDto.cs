using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Constraints;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.AddOffer
{
    public class AddOfferDto
    {
        public int AgencyId { get; set; }
        public IEnumerable<OfferDto> LodgingOffers{ get; set; }=new List<OfferDto>();
        
    }

    public class OfferDto
    {
        public int OfferId { get; set; }
        public int Price { get; set; }
    }
}