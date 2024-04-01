using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Excursion;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class ExcursionService : IExcursionService 
    {
        private readonly IExcursionRepository _excursionRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public ExcursionService(IAgencyRepository agencyRepository, IExcursionRepository excursionRepository,IMapper mapper)
        {
            _excursionRepository = excursionRepository;
            _agencyRepository = agencyRepository;
            _mapper = mapper;
        }
        public async Task<ExcursionDto> CreateExcursionAsync(ExcursionDto excursionDto)
        {
            var excursion = _mapper.Map<Domain.Entities.Excursion>(excursionDto);
            await _excursionRepository.CreateAsync(excursion);
            return _mapper.Map<ExcursionDto>(excursion);
        }
        public async Task DeleteExcursionByIdAsync(int excursionId)
        {
            var excursion = _excursionRepository.GetById(excursionId);
            var agencyID = excursion.AgencyID;
            var agency = _agencyRepository.GetById(agencyID);
            agency.Excursions.Remove(excursion);
            await _excursionRepository!.DeleteByIdAsync(excursionId);
        }        

        public async Task<IEnumerable<ExcursionDto>> ListExcursionAsync()
        {
            var excursions = await _excursionRepository.ListAsync();
            var list = excursions.ToList();
            List <ExcursionDto> excursionsfinal = new();
            for (int i = 0; i < excursions.Count(); i++)
            {
                excursionsfinal.Add(_mapper.Map<ExcursionDto>(list[i]));
            }
            return excursionsfinal;
        }

        public async Task<ExcursionDto> UpdateExcursionAsync(ExcursionDto excursionDto)
        {
            if (excursionDto == null)
            {
                throw new ArgumentNullException(nameof(excursionDto));
            }
            var excursion = _excursionRepository.GetById(excursionDto.Id);
            _mapper.Map(excursionDto, excursion);
            await _excursionRepository.UpdateAsync(excursion);
            return _mapper.Map<ExcursionDto>(excursion);
        }
    }
}