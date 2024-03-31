using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IFacilityService
    {
        Task<FacilityDto> CreateFacilityAsync(FacilityDto facilityDto);
        Task<FacilityDto> UpdateFacilityAsync(FacilityDto facilityDto);
        Task<IEnumerable<FacilityDto>> ListFacilityAsync();
        Task DeleteFacilityAsync(int facilityDto);
    }
}