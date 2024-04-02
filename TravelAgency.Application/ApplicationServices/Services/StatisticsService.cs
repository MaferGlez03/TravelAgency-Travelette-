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
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;

namespace TravelAgency.Application.ApplicationServices.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IPackageRepository _packageRepository;
    private readonly IMapper _mapper;

    public StatisticsService(IPackageRepository packageRepository, IMapper mapper, IHotelRepository hotelRepository)
    {
        _packageRepository = packageRepository;
        _mapper = mapper;
        _hotelRepository = hotelRepository;
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
    public async Task<PaginatedList<HotelDto>> HotelPackages(int pageNumber, int pageSize)
    {
        var packages =await  _packageRepository.GetPackageWithFacilities();
        List<HotelDto> hotelpackage = new List<HotelDto>();
        foreach (var package in packages)
        {
            foreach (var hotelId in package.PackageExtendedExcursions)
            {
                var hotel = await _hotelRepository.GetByIdAsync(hotelId);
                var mappedhotel=_mapper.Map<HotelDto>(hotel);
                if(!hotelpackage.Contains(mappedhotel))
                 hotelpackage.Add(mappedhotel);
            }
            
        }
        return PaginatedList<HotelDto>.CreatePaginatedListAsync(hotelpackage.OrderBy(x=>x.Name),pageNumber,pageSize);
    }

}