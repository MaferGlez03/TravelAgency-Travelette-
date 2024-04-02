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
using TravelAgency.Application.ApplicationServices.Maps.Dtos.FrequentTourist;
using TravelAgency.Application.Interfaces;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookAgency;
using Microsoft.AspNetCore.Http.Features;

namespace TravelAgency.Application.ApplicationServices.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IPackageRepository _packageRepository;
    private readonly IExcursionRepository _excursionRepository;
    private readonly IBookPackageRepository _bookPackageRepository;
    private readonly IBookExcursionRepository _bookExcursionRepository;
    private readonly IBookOfferRepository _bookOfferRepository;
    private readonly IMapper _mapper;

    public StatisticsService(IPackageRepository packageRepository, IExcursionRepository excursionRepository, IBookPackageRepository bookPackageRepository,IHotelRepository hotelRepository, IBookExcursionRepository bookExcursionRepository, IBookOfferRepository bookOfferRepository, IMapper mapper)
    {
        _packageRepository = packageRepository;
        _excursionRepository = excursionRepository;
        _bookPackageRepository = bookPackageRepository;
        _bookExcursionRepository = bookExcursionRepository;
        _bookOfferRepository = bookOfferRepository;
        _mapper = mapper;
        _hotelRepository = hotelRepository;
    }

    public async Task<PaginatedList<FrequentTouristDto>> FrequentTourists(int pageNumber, int pageSize)
    {
        var bookPackages = await _bookPackageRepository!.ListAsync();
        var list = bookPackages.ToList();
        List<FrequentTouristDto> frequentTourists = new List<FrequentTouristDto>();
        List<int> touristIDs = new List<int>();
        foreach (BookPackage bookPackage in list)
        {
            var touristId = bookPackage.TouristId;
            if(touristIDs.Contains(touristId))
            {
                FrequentTouristDto frequentTouristDto = new FrequentTouristDto
                {
                    Id = bookPackage.Tourist.Id,
                    Name = bookPackage.Tourist.Name,
                    Email = bookPackage.Tourist.Email
                };
                frequentTourists.Add(frequentTouristDto);
            }
            else touristIDs.Add(touristId);
        }
        return PaginatedList<FrequentTouristDto>.CreatePaginatedListAsync(frequentTourists, pageNumber, pageSize);
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
            if (list[i].Price <= meanPrice) continue;

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
        return PaginatedList<PackageResponseDto>.CreatePaginatedListAsync(packagesfinal, pageNumber, pageSize);
    }

    public async Task<PaginatedList<WeekendExcursionDto>> WeekendExcursions(int pageNumber, int pageSize)
    {
        var excursions = await _excursionRepository!.ListAsync();
        var list = excursions.ToList();
        List<WeekendExcursionDto> weekendExcursions = new List<WeekendExcursionDto>();

        foreach (Excursion excursion in list)
        {
            var day = excursion.ArrivalDate.DayOfWeek;
            if (day == DayOfWeek.Friday || day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
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
    public async Task<PaginatedList<HotelDto>> HotelPackages(int pageNumber, int pageSize)
    {
        var packages = await _packageRepository.GetPackageWithFacilities();
        List<HotelDto> hotelpackage = new List<HotelDto>();
        foreach (var package in packages)
        {
            foreach (var hotelId in package.PackageExtendedExcursions)
            {
                var hotel = await _hotelRepository.GetByIdAsync(hotelId);
                var mappedhotel = _mapper.Map<HotelDto>(hotel);
                if (!hotelpackage.Contains(mappedhotel))
                    hotelpackage.Add(mappedhotel);
            }

        }
        return PaginatedList<HotelDto>.CreatePaginatedListAsync(hotelpackage.OrderBy(x => x.Name), pageNumber, pageSize);
    }

    public async Task<PaginatedList<BookAgencyDto>> TotalBooksAgency(int pageNumber, int pageSize)
    {
        var packages = await _bookPackageRepository!.ListAsync();
        var excursions = await _bookExcursionRepository!.ListAsync();
        var offers = await _bookOfferRepository!.ListAsync();
        Dictionary<int, Tuple<int, double, string>> values = new Dictionary<int, Tuple<int, double, string>>();
        List<int> agenciesIds = new List<int>();

        foreach (BookPackage bookPackage in packages)
        {
            int id = bookPackage.Package.AgencyID;
            if(agenciesIds.Contains(id))
            {
                var acttuple = values[id];
                int t1 = acttuple.Item1 +1;
                double t2 = acttuple.Item2 + bookPackage.Price;

                var newtuple = new Tuple<int, double, string>( t1, t2, acttuple.Item3);
                values[id] = newtuple;
            }
            else 
            {
                agenciesIds.Add(id);
                values.Add(id,new Tuple<int, double, string>(1,bookPackage.Price, bookPackage.Package.agency.Name));
            }
        }

        foreach (BookExcursion bookExcursion in excursions)
        {
            int id = bookExcursion.Excursion.AgencyID;
            if(agenciesIds.Contains(id))
            {
                var acttuple = values[id];
                int t1 = acttuple.Item1 +1;
                double t2 = acttuple.Item2 + bookExcursion.TotalPrice;

                var newtuple = new Tuple<int, double, string>( t1, t2, acttuple.Item3);
                values[id] = newtuple;
            }
            else
            {
                agenciesIds.Add(id);
                values.Add(id,new Tuple<int, double, string>(1,bookExcursion.TotalPrice, bookExcursion.Excursion.agency.Name));
            }
        }

        foreach (BookOffer bookOffer in offers)
        {
            int id = bookOffer.AgencyOffer.AgencyId;
            if(agenciesIds.Contains(id))
            {
                var acttuple = values[id];
                int t1 = acttuple.Item1 +1;
                double t2 = acttuple.Item2 + bookOffer.Price;

                var newtuple = new Tuple<int, double, string>( t1, t2, acttuple.Item3);
                values[id] = newtuple;
            }
            else
            {
                agenciesIds.Add(id);
                values.Add(id,new Tuple<int, double, string>(1,bookOffer.Price, bookOffer.AgencyOffer.Agency.Name));
            }
        }

        List<BookAgencyDto> bookAgencies = new List<BookAgencyDto>();
        foreach (var item in values)
        {
            BookAgencyDto bookAgencyDto = new BookAgencyDto
            {
                AgencyId = item.Key,
                AgencyName = item.Value.Item3,
                TotalBooks = item.Value.Item1,
                ExpectedAmount = item.Value.Item2
            };
            bookAgencies.Add(bookAgencyDto);
        }

        return PaginatedList<BookAgencyDto>.CreatePaginatedListAsync(bookAgencies, pageNumber, pageSize);
    }
}