using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }
        public async Task<HotelDto> CreateHotelAsync(HotelDto hotelDto)
        {
            var hotel = _mapper.Map<Domain.Entities.Hotel>(hotelDto);
            await _hotelRepository.CreateAsync(hotel);
            return _mapper.Map<HotelDto>(hotel);
        }
        public async Task DeleteHotelByIdAsync(int hotelDto)
        {
            await _hotelRepository.DeleteByIdAsync(hotelDto);
        }


        public async Task<IEnumerable<HotelDto>> ListHotelAsync()
        {
            var hotels = await _hotelRepository.ListAsync();
            var list = hotels.ToList();
            List<HotelDto> hotelsfinal = new();
            for (int i = 0; i < hotels.Count(); i++)
            {
                hotelsfinal.Add(_mapper.Map<HotelDto>(list[i]));
            }
            return hotelsfinal;
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