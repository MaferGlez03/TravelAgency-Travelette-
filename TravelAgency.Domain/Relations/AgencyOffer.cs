using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Relations
{
    public class AgencyOffer: BaseEntity
    {
        public int LodgingOfferId { get; set; }
        public int AgencyId { get; set; }
        public double Price { get; set; }
        public  LodgingOffer? LodgingOffer { get; set; }
        public  Agency? Agency { get; set; }
    }
}