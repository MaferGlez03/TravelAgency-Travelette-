using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.ExtendedExcursion;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class ExtendedExcursionService : IExtendedExcursionService 
    {
        private readonly IExtendedExcursionRepository _extendedExcursionRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public ExtendedExcursionService(IAgencyRepository agencyRepository, IExtendedExcursionRepository extendedExcursionRepository,IMapper mapper)
        { 
            _extendedExcursionRepository = extendedExcursionRepository;
            _agencyRepository = agencyRepository;
            _mapper = mapper;
        }
        public async Task<ExtendedExcursionDto> CreateExtendedExcursionAsync(ExtendedExcursionDto extendedExcursionDto)
        {
            List<Hotel_ExtendedExcursion> _hotel_ExtendedExcursions = new List<Hotel_ExtendedExcursion>();

             foreach (int hotel in extendedExcursionDto.hotelDtos)
            {
                Hotel_ExtendedExcursion hotel_ExtendedExcursion = new Hotel_ExtendedExcursion{ Hotel_Id = hotel, ExtendedExcursion_Id = extendedExcursionDto.Id, ArrivalDate = extendedExcursionDto.ArrivalDate1};
                _hotel_ExtendedExcursions.Add(hotel_ExtendedExcursion);
            }

            ExtendedExcursion ee = new ExtendedExcursion
            {
                Id = extendedExcursionDto.Id,
                Name = extendedExcursionDto.Name,
                Capacity = extendedExcursionDto.Capacity,
                Price = extendedExcursionDto.Price,
                ArrivalDate = extendedExcursionDto.ArrivalDate,
                DepartureDate = extendedExcursionDto.DepartureDate,
                AgencyID = extendedExcursionDto.AgencyID,
                ArrivalPlace = extendedExcursionDto.ArrivalPlace,
                DeparturePlace = extendedExcursionDto.DeparturePlace,
                Guia = extendedExcursionDto.Guia,
                NumberOfDays = extendedExcursionDto.NumberOfDays,
                ArrivalDate1 = extendedExcursionDto.ArrivalDate1,
            };

             ee.AddExtendedExcursions(_hotel_ExtendedExcursions);

            var _extendedExcursion = await _extendedExcursionRepository!.CreateAsync(ee);

            return _mapper.Map<ExtendedExcursionDto>(_extendedExcursion);
        }
        public async Task DeleteExtendedExcursionAsync(int extendedExcursionId)
        {
            var extendedExcursion = _extendedExcursionRepository.GetById(extendedExcursionId);
            var agencyID = extendedExcursion.AgencyID;
            var agency = _agencyRepository.GetById(agencyID);
            agency.Excursions.Remove(extendedExcursion);
            await _extendedExcursionRepository!.DeleteByIdAsync(extendedExcursionId);
        }        

        public async Task<IEnumerable<ExtendedExcursionDto>> ListExtendedExcursionAsync()
        {
            var extendedExcursions = await _extendedExcursionRepository.ListAsync();
            var list = extendedExcursions.ToList();
            List <ExtendedExcursionDto> extendedExcursionsfinal = new();
            for (int i = 0; i < extendedExcursions.Count(); i++)
            {
                extendedExcursionsfinal.Add(_mapper.Map<ExtendedExcursionDto>(list[i]));
            }
            return extendedExcursionsfinal;
        }

        public async Task<ExtendedExcursionDto> UpdateExtendedExcursionAsync(ExtendedExcursionDto extendedExcursionDto)
        {
            if (extendedExcursionDto == null)
            {
                throw new ArgumentNullException(nameof(extendedExcursionDto));
            }
            var extendedExcursion = _extendedExcursionRepository.GetById(extendedExcursionDto.Id);
            _mapper.Map(extendedExcursionDto, extendedExcursion);
            await _extendedExcursionRepository.UpdateAsync(extendedExcursion);
            return _mapper.Map<ExtendedExcursionDto>(extendedExcursion);
        }
    }
}