using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency
{
    public class AgencywithOfferDto:AgencyDto
    {
        public IList<AgencyOfferDto> AgencyOffers{get;set;} =  new List<AgencyOfferDto>();
    }
    public class AgencyOfferDto
    {
        public LodgingOfferDto offer {get;set;}
        public double Price { get; set; }

    }
}