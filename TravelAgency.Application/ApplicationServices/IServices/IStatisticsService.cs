using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Excursion;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Package;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.WeekendExcursion;
using TravelAgency.Application.Common.PaginatedList;

namespace TravelAgency.Application.ApplicationServices.IServices;

public interface IStatisticsService 
{
    Task<PaginatedList<PackageResponseDto>> SpensivesPackageAsync(int pageNumber, int pageSize);
    Task<PaginatedList<WeekendExcursionDto>> WeekendExcursions(int pageNumber, int pageSize);
    Task<PaginatedList<HotelDto>> HotelPackages(int pageNumber, int pageSize);
}