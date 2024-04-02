using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookExcursion;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Excursion;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.ExtendedExcursion;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Package;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Security;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.ExtendedExcursion;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.Identity;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookPackage;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {

            CreateMap<User, UserDto>();
            CreateMap<RegisterDto, User>().ForMember(x => x.Nationality, o => o.MapFrom(c => c.Nacionality));
            CreateMap<LoginDto, User>();

            CreateMap<FacilityDto, Domain.Entities.Facility>();
            CreateMap<Domain.Entities.Facility, FacilityDto>();
            CreateMap<Domain.Entities.PackageFacility, FacilityDto>();

            CreateMap<AgencyDto, Domain.Entities.Agency>();
            CreateMap<Domain.Entities.Agency, AgencyDto>();

            CreateMap<BookOfferDto, Domain.Relations.BookOffer>();
            CreateMap<Domain.Relations.BookOffer, BookOfferDto>();

            CreateMap<BookPackageDto, Domain.Relations.BookPackage>();
            CreateMap<Domain.Relations.BookPackage, BookPackageDto>();

            CreateMap<BookExcursionDto, Domain.Relations.BookExcursion>();
            CreateMap<Domain.Relations.BookExcursion, BookExcursionDto>();

            CreateMap<ExcursionExtResponseDto, Domain.Relations.PackageExtendedExcursion>();
            CreateMap<Domain.Relations.PackageExtendedExcursion, ExcursionExtResponseDto>();

            CreateMap<HotelDto, Domain.Entities.Hotel>();
            CreateMap<Domain.Entities.Hotel, HotelDto>();

            CreateMap<HotelResponseDto, Domain.Entities.Hotel>();
            CreateMap<Domain.Entities.Hotel, HotelResponseDto>();

            CreateMap<ExcursionDto, Domain.Entities.Excursion>();
            CreateMap<Domain.Entities.Excursion, ExcursionDto>();

            CreateMap<ExtendedExcursionDto, Domain.Entities.ExtendedExcursion>();
            CreateMap<Domain.Entities.ExtendedExcursion, ExtendedExcursionDto>();
        

            CreateMap<LodgingOfferDto, Domain.Entities.LodgingOffer>()
            .ForMember(x => x.Id, o => o.MapFrom(c => c.Id));
            CreateMap<Domain.Entities.LodgingOffer, LodgingOfferDto>();


            CreateMap<ExcursionDto, Domain.Entities.Excursion>();
            CreateMap<Domain.Entities.Excursion, ExcursionDto>();


            CreateMap<LodgingOfferDtoResponse, Domain.Entities.LodgingOffer>();
            CreateMap<Domain.Entities.LodgingOffer, LodgingOfferDtoResponse>()
            .ForMember(x => x.hotelDto, o => o.MapFrom(c => c.Hotel!));


            CreateMap<PackageDto, Domain.Entities.Package>();
            CreateMap<Domain.Entities.Package, PackageDto>();
            CreateMap<Domain.Entities.Package, PackageResponseDto>();


            CreateMap<ExtendedExcursionDto, Domain.Entities.ExtendedExcursion>();
            CreateMap<Domain.Entities.ExtendedExcursion, ExtendedExcursionDto>();


        }
    }
}