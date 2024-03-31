using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.Common.Interfaces;

namespace TravelAgency.Infrastructure.DataAccess.IRepository
{
    public interface IAgencyRepository:IGenericRepository<Agency>
    {
          
    }
}