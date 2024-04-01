using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.Common.Utilities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Infrastructure.DataAccess.Repository
{
    public class PackageRepository:GenericRepository<Package>, IPackageRepository
    {
        public PackageRepository(TravelAgencyContext context):base(context)
        {
            
        }
        public async Task<IEnumerable<Package>> GetPackageWithFacilities()
        {
            return await entity.Include(x=>x.packageFacilities)
                            .ThenInclude(x=>x.facility)
                            .Include(x=>x.PackageExtendedExcursions)
                            .ThenInclude(x=>x.Excursion).ToListAsync();
        }
        
       
    }
}