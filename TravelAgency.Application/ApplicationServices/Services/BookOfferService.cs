using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookOffer;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Application.Interfaces;
using TravelAgency.Application.Validators.Entities;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.DataAccess.IRepository;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class BookOfferService : IBookOfferService
    {
        private readonly IUser _user;
        private readonly IAgencyOfferRepository _agencyOfferRepository;
        private readonly IBookOfferRepository _bookOfferRepository;
        private readonly ITouristRepository _touristRepository;
         private readonly IMapper _mapper;

        public BookOfferService(IAgencyOfferRepository agencyOfferRepository, ITouristRepository touristRepository, IUser user, IMapper mapper, IBookOfferRepository bookOfferRepository)
        {
            _agencyOfferRepository = agencyOfferRepository;
            _touristRepository = touristRepository;
            _user = user;
            _mapper = mapper;
            _bookOfferRepository = bookOfferRepository;
        }

        public async Task BookOfferByAdminAsync(BookOfferByAdminDto bookOfferDto)
        {

            var nationality = bookOfferDto.Nacionality;
            Nationality nationality1 = 0;
           var mappedNationality= _mapper.Map(nationality,nationality1);
        var tourist = new Domain.Entities.Tourist
                            {Name = bookOfferDto.UserName,
                             Nationality = mappedNationality.ToString(),
                             userId = _user.Id!};
            var savedTourist = await _touristRepository.CreateAsync(tourist);
            var bookOffer = _mapper.Map<BookOffer>(bookOfferDto);
            var agencyOffer = _agencyOfferRepository.GetById(bookOffer.AgencyOfferId);
            var days = (bookOfferDto.DepurateDate-bookOfferDto.ArrivalDate).Days;
            bookOffer.Price = days*agencyOffer.Price;
            savedTourist.AddReservation(bookOffer);
           await _touristRepository.UpdateAsync(savedTourist);

            
        }

        public async Task<PaginatedList<BookOffer>> ListReservesAsync(int pageNumber,int pageSize)
        {
            var reserves = await _bookOfferRepository.ListAsync();
           
            return  PaginatedList<BookOffer>.CreatePaginatedListAsync(reserves,pageNumber,pageSize) ;
        }
    }
}