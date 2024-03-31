using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Excursion;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IExcursionService
    {
        Task<ExcursionDto> CreateExcursionAsync(ExcursionDto excursionDto);
        Task<ExcursionDto> UpdateExcursionAsync(ExcursionDto excursionDto);
        Task<IEnumerable<ExcursionDto>> ListExcursionAsync();
        Task DeleteExcursionAsync(int excursionDto);
    }
}