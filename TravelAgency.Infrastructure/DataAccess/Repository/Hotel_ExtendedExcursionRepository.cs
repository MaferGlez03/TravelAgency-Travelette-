using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.Common.Utilities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Infrastructure.DataAccess.Repository
{
    public class Hotel_ExtendedExcursionRepository : GenericRepository<Hotel_ExtendedExcursion>, IHotel_ExtendedExcursionRepository
    {
        public Hotel_ExtendedExcursionRepository(TravelAgencyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Hotel_ExtendedExcursion>> GetHotel_ExtendedExcursions()
        {
           return await entity.Include(x => x.Hotel).ToListAsync();
        }

        
    }
}