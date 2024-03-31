using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.AgencyOffer;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class AgencyOfferService : IAgencyOfferService
    {
        private readonly IAgencyOfferRepository _agencyOfferRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly ILodgingOfferRepository _lodgingOfferRepository;
        private readonly IMapper _mapper;

        public AgencyOfferService(IAgencyOfferRepository agencyOfferRepository, IAgencyRepository agencyRepository, ILodgingOfferRepository lodgingOfferRepository, IMapper mapper)
        {
            _agencyOfferRepository = agencyOfferRepository;
            _agencyRepository = agencyRepository;
            _lodgingOfferRepository = lodgingOfferRepository;
            _mapper = mapper;
        }

        public async Task<AgencyOfferResponseDto> CreateAgencyOfferAsync(int agencyId, int offerId, double price = 0)
        {
            var AgencyOffer = new AgencyOffer
            {
                AgencyId = agencyId,
                LodgingOfferId = offerId,
                Price = price 
                
            };
            var savedAgencyOffer = await _agencyOfferRepository.CreateAsync(AgencyOffer);
            var agencies = await _agencyRepository.ListAsync();
            var agenciesfiltered = agencies.Where(x =>x.Id == savedAgencyOffer.AgencyId).ToList();
            var offers = await _lodgingOfferRepository.ListAsync();
            var offersfiltered = offers.Where(x =>x.Id == savedAgencyOffer.LodgingOfferId).ToList();
            for (int i = 0; i < agenciesfiltered.Count; i++)
            {
                agenciesfiltered[i].AgencyOffers.Add(savedAgencyOffer);
                
            }
            for (int i = 0; i < offersfiltered.Count; i++)
            {
                offersfiltered[i].AgencyOffers.Add(savedAgencyOffer);

            }

                return  _mapper.Map<AgencyOfferResponseDto>(savedAgencyOffer);

        }

        public async Task DeleteAgencyOfferByIdAsync(int agencyId, int offerId)
        {
            var agencyOffer = _agencyOfferRepository.GetById(offerId);
            var agency = _agencyRepository.GetById(agencyId);
            agency.AgencyOffers.Remove(agencyOffer);
            var lodgingOffer= _lodgingOfferRepository.GetById(offerId);
            lodgingOffer.AgencyOffers.Remove(agencyOffer);

            await _agencyOfferRepository.DeleteByIdAsync(offerId);
        }

        public Task<IEnumerable<AgencyOfferResponseDto>> ListAgencyOfferAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AgencyOfferResponseDto> UpdateAgencyOfferAsync(int price)
        {
            throw new NotImplementedException();
        }
    }
}