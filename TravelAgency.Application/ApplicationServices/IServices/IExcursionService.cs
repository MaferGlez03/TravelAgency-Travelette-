using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Excursion;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IExcursionService
    {
        Task<ExcursionDto> CreateExcursionAsync(ExcursionDto excursionDto);
        Task<ExcursionDto> UpdateExcursionAsync(ExcursionDto excursionDto);
        Task<PaginatedList<ExcursionDto>> ListExcursionAsync(int pageNumber,int pageSize);
        Task DeleteExcursionByIdAsync(int excursionDto);
    }
}