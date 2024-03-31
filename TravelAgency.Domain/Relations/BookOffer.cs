using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Relations
{
    public class BookOffer:BaseEntity
    {
        public int TouristId { get; set; }
        public Tourist? Tourist { get; set; }
        public int AgencyOfferId { get; set; }
        public AgencyOffer? AgencyOffer { get; set; }
        public double Price { get; set; }
        public DateTime ArrivalDate { get; set; } = DateTime.MinValue;
        public DateTime DepurateDate { get; set; }=DateTime.MaxValue;
    }
}