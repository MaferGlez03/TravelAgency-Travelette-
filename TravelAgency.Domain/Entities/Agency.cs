using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Common;
using TravelAgency.Domain.Relations;

namespace TravelAgency.Domain.Entities
{
    public class Agency : BaseEntity
    {
        //!Set restrictions
        public string Name { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ElectronicAddress { get; set; } = null!;
        public IList<AgencyOffer> AgencyOffers { get; private set; } = new List<AgencyOffer>();
        public IList<Package> Packages { get; private set;} = new List<Package>();

        #region Methods

        public void AddOffer(AgencyOffer offer)
        {
            if (!AgencyOffers.Contains(offer))
            {
                offer.Agency = this;
                AgencyOffers.Add(offer);
            }

        }

        public void AddOffers(IEnumerable<AgencyOffer> offers)
        {
            foreach (var offer in offers)
            {
                AddOffer(offer);
            }

        }
        public void DeleteOffer(AgencyOffer offer)
        {

            if (AgencyOffers.Contains(offer))
            {
                AgencyOffers.Remove(offer);
            }

        }
        public void CleanOffers()
        {
            AgencyOffers.Clear();

        }
        #endregion

    }
}