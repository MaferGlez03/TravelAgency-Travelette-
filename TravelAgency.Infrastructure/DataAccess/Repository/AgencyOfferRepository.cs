using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.Common.Utilities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Infrastructure.DataAccess.Repository
{
    public class AgencyOfferRepository : GenericRepository<AgencyOffer>, IAgencyOfferRepository
    {
        public AgencyOfferRepository(TravelAgencyContext context) : base(context)
        {
        }
    }
}