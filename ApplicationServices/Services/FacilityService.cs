using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class FacilityService : IFacilityService 
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public FacilityService(IFacilityRepository facilityRepository,IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }
        public async Task<FacilityDto> CreateFacilityAsync(FacilityDto facilityDto)
        {
            var facility = _mapper.Map<Domain.Entities.Facility>(facilityDto);
            await _facilityRepository.CreateAsync(facility);
            return _mapper.Map<FacilityDto>(facility);
        }
        public async Task DeleteFacilityAsync(int facilityId)
        {
            await _facilityRepository.DeleteByIdAsync(facilityId);
        }

        

        public async Task<IEnumerable<FacilityDto>> ListFacilityAsync()
        {
            var facilities = await _facilityRepository.ListAsync();
            var list = facilities.ToList();
            List <FacilityDto> facilitiesfinal = new();
            for (int i = 0; i < facilities.Count(); i++)
            {
                facilitiesfinal.Add(_mapper.Map<FacilityDto>(list[i]));
            }
            return facilitiesfinal;
        }

        public async Task<FacilityDto> UpdateFacilityAsync(FacilityDto facilityDto)
        {
            var facility = _facilityRepository.GetById(facilityDto.Id);
            _mapper.Map(facilityDto, facility);
            await _facilityRepository.UpdateAsync(facility);
            return _mapper.Map<FacilityDto>(facility);
        }
    }
}