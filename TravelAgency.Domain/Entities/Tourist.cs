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
        public IList<BookExcursion> BookExcursions {get; set;} = new List<BookExcursion>();
         public IList<BookPackage> BookPackages{get; private set;}= new List<BookPackage>();
        // public void AddExcursions(List<BookExcursion> _bookExcursions)
        // {
        //     foreach (BookExcursion excursion in _bookExcursions)
        //     {
        //         BookExcursions.Add(excursion);
        //     }
        //}
        
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
        public void AddReservation(BookPackage package)
        {
            
            if (!BookPackages.Contains(package))
            {
                package.Tourist = this;
                BookPackages.Add(package);
            }

        }

        public void DeleteReservation(BookPackage package)
        {

            if (BookPackages.Contains(package))
            {
                BookPackages.Remove(package);
            }

        }
        public void CleanPackages()
        {
            BookPackages.Clear();

        }


         public void AddReservation(BookExcursion excursion) 
        {            
            if (!BookExcursions.Contains(excursion))
            {
                excursion.Tourist = this;
                BookExcursions.Add(excursion);
            }
        }
        public void DeleteReservation(BookExcursion excursion)
        {
            if (BookExcursions.Contains(excursion))
            {
                BookExcursions.Remove(excursion);
            }
        }
        public void CleanExcursions()
        {
            BookExcursions.Clear();
        }
        #endregion
    }
}