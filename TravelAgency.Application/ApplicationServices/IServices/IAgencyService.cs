using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IAgencyService
    {
        Task<AgencyDto> CreateAgencyAsync(AgencyDto agencyDto);
        Task<AgencyDto> UpdateAgencyAsync(AgencyDto agencyDto);
        Task<IEnumerable<AgencyDto>> ListAgencyAsync();
        Task DeleteAgencyByIdAsync(int agencyDto);
    }
}