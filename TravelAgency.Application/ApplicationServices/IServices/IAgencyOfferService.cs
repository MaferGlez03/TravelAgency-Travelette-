using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.AgencyOffer;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IAgencyOfferService
    {
        Task<AgencyOfferResponseDto> CreateAgencyOfferAsync(int agencyId,int offerId,double price);
        Task<AgencyOfferResponseDto> UpdateAgencyOfferAsync(int price);
        Task<IEnumerable<AgencyOfferResponseDto>> ListAgencyOfferAsync();
        Task DeleteAgencyOfferByIdAsync(int agencyId, int offerId);
    }
}