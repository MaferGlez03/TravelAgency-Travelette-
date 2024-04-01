using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IFacilityService
    {
        Task<FacilityDto> CreateFacilityAsync(FacilityDto facilityDto);
        Task<FacilityDto> UpdateFacilityAsync(FacilityDto facilityDto);
        Task<PaginatedList<FacilityDto>> ListFacilityAsync(int pageNumber,int pageSize);
        Task DeleteFacilityAsync(int facilityDto);
    }
}