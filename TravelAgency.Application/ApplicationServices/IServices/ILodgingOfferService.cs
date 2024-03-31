using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface ILodgingOfferService
    {
        Task<LodgingOfferDto> CreateLodgingOfferAsync(LodgingOfferDto lodgingOfferDto);
        Task<LodgingOfferDto> UpdateLodgingOfferAsync(LodgingOfferDto lodgingOfferDto);
        Task<IEnumerable<LodgingOfferDtoResponse>> ListLodgingOfferAsync();
        Task DeleteLodgingOfferByIdAsync(int lodgingOfferId);
    }
}