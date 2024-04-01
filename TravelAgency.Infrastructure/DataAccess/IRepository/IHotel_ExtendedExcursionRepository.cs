using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.Common.Interfaces;

namespace TravelAgency.Infrastructure.DataAccess.IRepository
{
    public interface IHotel_ExtendedExcursionRepository : IGenericRepository<Hotel_ExtendedExcursion>
    {
        Task<IEnumerable<Hotel_ExtendedExcursion>> GetHotel_ExtendedExcursions();
    }
    
}