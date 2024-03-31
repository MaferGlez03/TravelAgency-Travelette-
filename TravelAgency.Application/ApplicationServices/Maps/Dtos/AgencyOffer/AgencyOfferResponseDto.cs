using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.AgencyOffer
{
    public class AgencyOfferResponseDto
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public int LodgingOfferId { get; set; }
        public AgencyDto agencyDto { get; set; }
       public List<LodgingOfferDto> offers {get;set;} = new List<LodgingOfferDto>();
    }
}