using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Package;
using TravelAgency.Application.Common.PaginatedList;

namespace TravelAgency.Application.ApplicationServices.IServices;

public interface IStatisticsService 
{
    Task<PaginatedList<PackageResponseDto>> SpensivesPackageAsync(int pageNumber, int pageSize);
}