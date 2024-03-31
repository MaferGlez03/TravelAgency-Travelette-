using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.ExtendedExcursion;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IExtendedExcursionService
    {
        Task<ExtendedExcursionDto> CreateExtendedExcursionAsync(ExtendedExcursionDto extendedExcursionDto);
        Task<ExtendedExcursionDto> UpdateExtendedExcursionAsync(ExtendedExcursionDto extendedExcursionDto);
        Task<IEnumerable<ExtendedExcursionDto>> ListExtendedExcursionAsync();
        Task DeleteExtendedExcursionAsync(int extendedExcursionDto);
    }
}