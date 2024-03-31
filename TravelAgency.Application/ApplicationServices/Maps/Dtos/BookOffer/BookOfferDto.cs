using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.BookOffer
{
    public class BookOfferDto
    {
        public int AgencyOfferId { get; set; }
        public DateTime ArrivalDate { get; set; } = DateTime.MinValue;
        public DateTime DepurateDate { get; set; }=DateTime.MaxValue;
    }
}