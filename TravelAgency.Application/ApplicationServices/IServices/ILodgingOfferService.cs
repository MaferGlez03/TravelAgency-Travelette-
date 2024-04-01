using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Application.Common.PaginatedList;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface ILodgingOfferService
    {
        Task<LodgingOfferDto> CreateLodgingOfferAsync(LodgingOfferDto lodgingOfferDto);
        Task<LodgingOfferDto> UpdateLodgingOfferAsync(LodgingOfferDto lodgingOfferDto);
       Task<PaginatedList<LodgingOfferDtoResponse>> ListLodgingOfferAsync(int pageNumber,int pageSize);
        Task DeleteLodgingOfferByIdAsync(int lodgingOfferId);
    }
}