using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Excursion;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
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

             CreateMap<HotelResponseDto, Domain.Entities.Hotel>();
             CreateMap<Domain.Entities.Hotel, HotelResponseDto>();

             CreateMap<LodgingOfferDto, Domain.Entities.LodgingOffer>()
             .ForMember(x=>x.Id,o=>o.MapFrom(c=>c.Id));
             CreateMap<Domain.Entities.LodgingOffer, LodgingOfferDto>();

             CreateMap<ExcursionDto, Domain.Entities.Excursion>();
             CreateMap<Domain.Entities.Excursion, ExcursionDto>();
        

             CreateMap<LodgingOfferDtoResponse, Domain.Entities.LodgingOffer>();
             CreateMap<Domain.Entities.LodgingOffer, LodgingOfferDtoResponse>()
             .ForMember(x=>x.hotelDto, o=>o.MapFrom(c=>c.Hotel!));

             


        }
    }
}