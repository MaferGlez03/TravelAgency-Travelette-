using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.ExtendedExcursion;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class ExtendedExcursionService : IExtendedExcursionService 
    {
        private readonly IExtendedExcursionRepository _extendedExcursionRepository;
        private readonly IMapper _mapper;

        public ExtendedExcursionService(IExtendedExcursionRepository extendedExcursionRepository,IMapper mapper)
        {
            _extendedExcursionRepository = extendedExcursionRepository;
            _mapper = mapper;
        }
        public async Task<ExtendedExcursionDto> CreateExtendedExcursionAsync(ExtendedExcursionDto extendedExcursionDto)
        {
            var extendedExcursion = _mapper.Map<Domain.Entities.ExtendedExcursion>(extendedExcursionDto);
            await _extendedExcursionRepository.CreateAsync(extendedExcursion);
            return _mapper.Map<ExtendedExcursionDto>(extendedExcursion);
        }
        public async Task DeleteExtendedExcursionAsync(int extendedExcursionId)
        {
            await _extendedExcursionRepository.DeleteByIdAsync(extendedExcursionId);
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
            var extendedExcursion = _extendedExcursionRepository.GetById(extendedExcursionDto.Id);
            _mapper.Map(extendedExcursionDto, extendedExcursion);
            await _extendedExcursionRepository.UpdateAsync(extendedExcursion);
            return _mapper.Map<ExtendedExcursionDto>(extendedExcursion);
        }
    }
}