using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class HotelService : IHotelService
    {
        private readonly ILodgingOfferRepository? _lodgingOfferRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
 
        public HotelService(ILodgingOfferRepository lodgingOfferRepository, IHotelRepository hotelRepository, IMapper mapper)
        {
            _lodgingOfferRepository =lodgingOfferRepository;
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }
        public async Task<HotelDto> CreateHotelAsync(HotelDto hotelDto)
        {
            var hotel = _mapper.Map<Domain.Entities.Hotel>(hotelDto);
            var savedHotel =await _hotelRepository.CreateAsync(hotel);
            return _mapper.Map<HotelDto>(savedHotel);
        }
        public async Task DeleteHotelByIdAsync(int hotelDto)
        {
            await _hotelRepository.DeleteByIdAsync(hotelDto);
        }


        public async Task<PaginatedList<HotelResponseDto>> ListHotelAsync(int pageNumber,int pageSize)
        { 
            var hotels = await _hotelRepository.ListAsync();
            var list = hotels.ToList();
            List<HotelResponseDto> hotelsfinal = new();
            for (int i = 0; i < hotels.Count(); i++)
            {
                hotelsfinal.Add(_mapper.Map<HotelResponseDto>(list[i]));
                var offers = await _lodgingOfferRepository!.ListAsync();
                var offersfiltered= offers.Where(x => x.HotelId == list[i].Id).ToList();
                for (int j = 0; j < offersfiltered.Count(); j++)
                {
                    hotelsfinal[i].lodgingOffers.Add(_mapper.Map<LodgingOfferDto>(offersfiltered[j]));
                }
                
            }
            return  PaginatedList<HotelResponseDto>.CreatePaginatedListAsync(hotelsfinal,pageNumber,pageSize);
        }

        public async Task<HotelDto> UpdateHotelAsync(HotelDto hotelDto)
        {
            var hotel = _hotelRepository.GetById(hotelDto.Id);
            _mapper.Map(hotelDto,hotel);
            await _hotelRepository.UpdateAsync(hotel);
            return _mapper.Map<HotelDto>(hotel);
        }
    }
}