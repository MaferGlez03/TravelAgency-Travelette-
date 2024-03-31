using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class LodgingOfferService : ILodgingOfferService
    {
        private readonly ILodgingOfferRepository? _lodgingOfferRepository;
        public readonly IHotelRepository? _hotelrepository;
        private readonly IMapper _mapper;

        public LodgingOfferService(IHotelRepository hotelrepository, ILodgingOfferRepository lodgingOfferRepository, IMapper mapper)
        {
            _hotelrepository = hotelrepository;
            _lodgingOfferRepository = lodgingOfferRepository;
            _mapper = mapper;
        }

        public async Task<LodgingOfferDto> CreateLodgingOfferAsync(LodgingOfferDto lodgingOfferDto)
        {
            //!MAYBE I SHOULD ADD THE OFFER CREATED TO THE CORRESPOND HOTEL LIST.
            var lodgingOffer = _mapper.Map<Domain.Entities.LodgingOffer>(lodgingOfferDto);
            var _lodgingOffer = await _lodgingOfferRepository!.CreateAsync(lodgingOffer);
            var hotel =_hotelrepository!.GetById(_lodgingOffer.HotelId);
            hotel.lodgingOffers.Add(_lodgingOffer);
            return _mapper.Map<LodgingOfferDto>(_lodgingOffer);
        }

        public async Task DeleteLodgingOfferByIdAsync(int lodgingOfferId)
        {
            await _lodgingOfferRepository!.DeleteByIdAsync(lodgingOfferId);
        }

        public async Task<IEnumerable<LodgingOfferDtoResponse>> ListLodgingOfferAsync()
        {
            //!PROBLEMS TO SHOW HOTEL PROPERTIES.
            var lodgingOffers = _lodgingOfferRepository!.GetLodgingOffers();
            var list = lodgingOffers.ToList();
            List<LodgingOfferDtoResponse> lodgingOffersfinal = new();
            for (int i = 0; i < lodgingOffers.Count(); i++)
            {
                lodgingOffersfinal.Add(_mapper.Map<LodgingOfferDtoResponse>(list[i]));
              
            }
            return lodgingOffersfinal;
        }

        public async Task<LodgingOfferDto> UpdateLodgingOfferAsync(LodgingOfferDto lodgingOfferDto)
        {
            var lodgingOffer = _lodgingOfferRepository.GetById(lodgingOfferDto.Id);
            _mapper.Map(lodgingOfferDto, lodgingOffer);
            await _lodgingOfferRepository.UpdateAsync(lodgingOffer);
            return _mapper.Map<LodgingOfferDto>(lodgingOffer);
        }
    }
}