using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Package;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.ExtendedExcursion;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.DataAccess.IRepository;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Excursion;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.WeekendExcursion;

namespace TravelAgency.Application.ApplicationServices.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IPackageRepository _packageRepository;
    private readonly IExcursionRepository _excursionRepository;
    private readonly IMapper _mapper;

    public StatisticsService(IPackageRepository packageRepository, IExcursionRepository excursionRepository, IMapper mapper)
    {
        _packageRepository = packageRepository;
        _excursionRepository = excursionRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PackageResponseDto>> SpensivesPackageAsync(int pageNumber, int pageSize)
    {
        var packages = await _packageRepository!.GetPackageWithFacilities();
        var list = packages.ToList();
        List<PackageResponseDto> packagesfinal = new();
        double totalPrice = 0;

        for (int i = 0; i < packages.Count(); i++)
        {
            totalPrice += list[i].Price;
        }
        double meanPrice = totalPrice / packages.Count();

        for (int i = 0; i < packages.Count(); i++)
        {
            if(list[i].Price <= meanPrice) continue;

            packagesfinal.Add(_mapper.Map<PackageResponseDto>(list[i]));
            foreach (var facility in list[i].packageFacilities)
            {
                packagesfinal[i].Facilities.Add(_mapper.Map<FacilityDto>(facility));
            }
            foreach (var excursion in list[i].PackageExtendedExcursions)
            {
                packagesfinal[i].Excursions.Add(_mapper.Map<ExcursionExtResponseDto>(excursion));
            }
        }
       return  PaginatedList<PackageResponseDto>.CreatePaginatedListAsync(packagesfinal,pageNumber,pageSize);
    }

    public async Task<PaginatedList<WeekendExcursionDto>> WeekendExcursions(int pageNumber, int pageSize)
    {
        var excursions = await _excursionRepository!.ListAsync();
        var list = excursions.ToList();
        List<WeekendExcursionDto> weekendExcursions = new List<WeekendExcursionDto>();

        foreach (Excursion excursion in list)
        {
            var day = excursion.ArrivalDate.DayOfWeek;
            if( day == DayOfWeek.Friday || day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            {
                WeekendExcursionDto weekendExcursionDto = new WeekendExcursionDto
                {
                    Id = excursion.Id,
                    AgencyID = excursion.AgencyID,
                    Name = excursion.Name,
                    ArrivalDate = excursion.ArrivalDate,
                    DepartureDate = excursion.DepartureDate,
                    ArrivalPlace = excursion.ArrivalPlace,
                    DeparturePlace = excursion.DeparturePlace
                };
                weekendExcursions.Add(weekendExcursionDto);
            } 
        }

        var sorted_list = weekendExcursions.OrderBy(date => date.ArrivalDate);
        
        return PaginatedList<WeekendExcursionDto>.CreatePaginatedListAsync(sorted_list, pageNumber, pageSize);
    }
}