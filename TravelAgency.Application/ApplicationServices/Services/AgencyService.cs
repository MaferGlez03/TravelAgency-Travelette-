using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class AgencyService : IAgencyService
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public AgencyService(IAgencyRepository agencyRepository,IMapper mapper)
        {
            _agencyRepository = agencyRepository;
            _mapper = mapper;
        }
        public async Task<AgencyDto> CreateAgencyAsync(AgencyDto agencyDto)
        {
            var agency = _mapper.Map<Domain.Entities.Agency>(agencyDto);
            await _agencyRepository.CreateAsync(agency);
            return _mapper.Map<AgencyDto>(agency);
        }
        public async Task DeleteAgencyByIdAsync(int agencyDto)
        {
            await _agencyRepository.DeleteByIdAsync(agencyDto);
        }


        public async Task<IEnumerable<AgencyDto>> ListAgencyAsync()
        {
            var agencies = await _agencyRepository.ListAsync();
            var list = agencies.ToList();
            List <AgencyDto> agenciesfinal = new();
            for (int i = 0; i < agencies.Count(); i++)
            {
                agenciesfinal.Add(_mapper.Map<AgencyDto>(list[i]));
            }
            return agenciesfinal;
        }

        public async Task<AgencyDto> UpdateAgencyAsync(AgencyDto agencyDto)
        {
            var agency = _agencyRepository.GetById(agencyDto.Id);
            _mapper.Map(agencyDto,agency);
            await _agencyRepository.UpdateAsync(agency);
            return _mapper.Map<AgencyDto>(agency);
        }
    }
}