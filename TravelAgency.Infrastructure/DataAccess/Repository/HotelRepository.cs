using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.Common.Utilities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Infrastructure.DataAccess.Repository
{
    public class HotelRepository:GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(TravelAgencyContext context):base(context)
        {
            
        }
        
    }
}