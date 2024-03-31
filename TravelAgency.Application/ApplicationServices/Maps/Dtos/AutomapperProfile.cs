using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Package;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Security;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
             
             CreateMap<User, UserDto>();
             CreateMap<RegisterDto, User>();
             CreateMap<LoginDto, User>();

             CreateMap<FacilityDto, Domain.Entities.Facility>();
             CreateMap<Domain.Entities.Facility,FacilityDto>();

             CreateMap<AgencyDto, Domain.Entities.Agency>();
             CreateMap<Domain.Entities.Agency, AgencyDto>();

             CreateMap<HotelDto, Domain.Entities.Hotel>();
             CreateMap<Domain.Entities.Hotel, HotelDto>();

             CreateMap<LodgingOfferDto, Domain.Entities.LodgingOffer>();
             CreateMap<Domain.Entities.LodgingOffer, LodgingOfferDto>();

             CreateMap<LodgingOfferDtoResponse, Domain.Entities.LodgingOffer>();
             CreateMap<Domain.Entities.LodgingOffer, LodgingOfferDtoResponse>();

             CreateMap<PackageDto, Domain.Entities.Package>();
             CreateMap<Domain.Entities.Package, PackageDto>();


        }
    }
}