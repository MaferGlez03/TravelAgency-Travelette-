using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.AddOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.DataAccess.IRepository;
using TravelAgency.Application.Common.Mappings;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class AgencyService :IAgencyService
    {

        private readonly IAgencyOfferRepository _agencyOfferRepository;
        private readonly IAgencyRepository _agencyRepository;
                private readonly IMapper _mapper;

        public AgencyService(IAgencyRepository agencyRepository, IMapper mapper, IAgencyOfferRepository agencyOfferRepository)
        {
            _agencyRepository = agencyRepository;
            _mapper = mapper;
            _agencyOfferRepository = agencyOfferRepository;
        }


        public async Task AddOffers(AddOfferDto addOfferDto)
        {
            var agency = _agencyRepository.GetById(addOfferDto.AgencyId);
            if (agency is not null)
            {
                var newoffers = new List<AgencyOffer>();
                foreach (var offer in addOfferDto.LodgingOffers)
                {
                    newoffers.Add(new AgencyOffer
                    {
                        LodgingOfferId = offer.OfferId,
                        Price = offer.Price
                    });
                    
                }
                agency.AddOffers(newoffers);

                await _agencyRepository.UpdateAsync(agency);

            }
            else throw new Exception("Agency doesn't exist");
            
        }

        public async Task<AgencyDto> CreateAgencyAsync(AgencyDto agencyDto)
        {
            var agency = _mapper.Map<Domain.Entities.Agency>(agencyDto);
            var savedAgency = await _agencyRepository.CreateAsync(agency);
            return _mapper.Map<AgencyDto>(savedAgency);
        }
        public async Task DeleteAgencyByIdAsync(int agencyDto)
        {
                        await _agencyRepository.DeleteByIdAsync(agencyDto);
        }

        public async Task DeleteOffers(int agencyOfferId)
        {
            var agencyOffer = _agencyOfferRepository.GetById(agencyOfferId);
            var agency = _agencyRepository.GetById(agencyOffer.AgencyId);
            agency.DeleteOffer(agencyOffer);
            await _agencyRepository.UpdateAsync(agency);
        }

        public async Task<PaginatedList<AgencyDto>> ListAgencyAsync(int pageNumber,int pageSize)
        {
            var agencies = await _agencyRepository.ListAsync();
            var list = agencies.ToList();
            List <AgencyDto> agenciesfinal = new();
            for (int i = 0; i < agencies.Count(); i++)
            {
                agenciesfinal.Add(_mapper.Map<AgencyDto>(list[i]));
            }
            

            return PaginatedList<AgencyDto>.CreatePaginatedListAsync(agenciesfinal,pageNumber,pageSize);
        }


        public async Task<AgencyDto> UpdateAgencyAsync(AgencyDto agencyDto)
        {
            var agency = _agencyRepository.GetById(agencyDto.Id);
            _mapper.Map(agencyDto,agency);
            await _agencyRepository.UpdateAsync(agency);
            return _mapper.Map<AgencyDto>(agency);
        }
    }
}