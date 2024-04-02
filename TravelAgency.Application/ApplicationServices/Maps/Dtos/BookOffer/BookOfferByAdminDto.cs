using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.BookOffer
{
    public class BookOfferByAdminDto:BookOfferDto
    {
        public string Email {get; set;} = null!;
        public string UserName {get; set;} = null!;
        public int Nacionality{get;set;} 
        
    }
}