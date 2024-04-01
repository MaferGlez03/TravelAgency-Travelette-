using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Relations;

namespace TravelAgency.Domain.Entities
{
    public class Hotel:BaseEntity
    {
        //!Set restrictions
        public string Name {get; set;} = null!;
        public string Category{get; set;} = null!;
        public string Address {get; set;} = null!;
        public IList<LodgingOffer> lodgingOffers{get; private set;} = new List<LodgingOffer>();
        public IList<Hotel_ExtendedExcursion> Hotel_ExtendedExcursions {get; private set;} = new List<Hotel_ExtendedExcursion>();

    }
}