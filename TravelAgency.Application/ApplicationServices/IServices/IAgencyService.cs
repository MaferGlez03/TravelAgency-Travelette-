using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.AddOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.DataAccess.Filters;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IAgencyService
    {
        Task<AgencyDto> CreateAgencyAsync(AgencyDto agencyDto);
        Task<AgencyDto> UpdateAgencyAsync(AgencyDto agencyDto);
        //Task<IEnumerable<AgencyDto>> ListAgencyAsync();
        Task<PaginatedList<AgencyDto>> ListAgencyAsync(int pageNumber,int pageSize);
        Task<PaginatedList<Agency>> FindAllAgenciesAsync(AgencyFilters? filters ,int pageNumber, int pageSize);
        Task DeleteAgencyByIdAsync(int agencyDto);
        Task AddOffers(AddOfferDto addOfferDto);
        Task DeleteOffers(int agencyOfferId);
    }
}