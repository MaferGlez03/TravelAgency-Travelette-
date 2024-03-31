using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Relations;

namespace TravelAgency.Domain.Entities
{
    public class Tourist:BaseEntity
    {
        //!Set restrictions
        public string userId {get;set;}
        public string Name {get; set;} = null!;
        public string Nationality {get; set;} = null!;
        public IList<BookOffer> BookOffers {get;set;} = new List<BookOffer>();

        
        #region Methods

        public void AddReservation(BookOffer offer)
        {
            
            if (!BookOffers.Contains(offer))
            {
                offer.Tourist = this;
                BookOffers.Add(offer);
            }

        }

        public void DeleteReservation(BookOffer offer)
        {

            if (BookOffers.Contains(offer))
            {
                BookOffers.Remove(offer);
            }

        }
        public void CleanOffers()
        {
            BookOffers.Clear();

        }
        #endregion
    }
}