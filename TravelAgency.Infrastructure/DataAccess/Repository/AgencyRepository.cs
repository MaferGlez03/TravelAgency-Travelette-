using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.Common.Utilities;
using TravelAgency.Infrastructure.DataAccess.Filters;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Infrastructure.DataAccess.Repository
{
    public class AgencyRepository:GenericRepository<Agency>, IAgencyRepository
    {
        public AgencyRepository(TravelAgencyContext context):base(context)
        {
            
        }
        
        public async Task<IEnumerable<Agency>> FindAllAgenciesAsync(AgencyFilters? filters)
        {
            IQueryable<Agency> query = entity.AsQueryable();
            
            if(filters is not null)
            {
                if(!string.IsNullOrWhiteSpace(filters.AgencyName))
                query = query.Where(a => a.Name.Contains(filters.AgencyName));

                 if(filters.AgencyNameList.Any())
                query = query.Where(a => filters.AgencyNameList.Contains(a.Name));
                
                 if(filters.HotelId > 0)
                query = query.Where(a => a.AgencyOffers.Any(o => o.LodgingOffer!.HotelId == filters.HotelId));
               
                // if(filters.IncludeOffers)
                // query.Include(a => a.AgencyOffers).ThenInclude(x =>x.LodgingOffer)
                // .ThenInclude(l => l.Hotel);
               
            }

           return query.ToList();
        }
       
    }
}