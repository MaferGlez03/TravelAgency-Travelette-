using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookExcursion;
using TravelAgency.Application.Interfaces;
using TravelAgency.Application.Validators.Entities;
using TravelAgency.Domain.Relations; 
using TravelAgency.Infrastructure.DataAccess.IRepository;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class BookExcursionService : IBookExcursionService
    { 
        private readonly IUser _user;
        private readonly IExcursionRepository _excursionRepository;
        private readonly IBookExcursionRepository _bookExcursionRepository;
        private readonly ITouristRepository _touristRepository;
         private readonly IMapper _mapper;

        public BookExcursionService(IExcursionRepository excursionRepository, ITouristRepository touristRepository, IUser user, IMapper mapper, IBookExcursionRepository bookExcursionRepository)
        {
            _excursionRepository = excursionRepository;
            _touristRepository = touristRepository;
            _user = user;
            _mapper = mapper;
            _bookExcursionRepository = bookExcursionRepository;
        }

        public async Task BookExcursionByAdminAsync(BookExcursionByAdminDto bookExcursionDto)
        {

            var nationality = bookExcursionDto.Nacionality;
            Nationality nationality1 = 0;
           var mappedNationality= _mapper.Map(nationality,nationality1);
        var tourist = new Domain.Entities.Tourist
                            {Name = bookExcursionDto.UserName,
                             Nationality = mappedNationality.ToString(),
                             userId = _user.Id!,
                             Email = bookExcursionDto.Email
                            };
            var savedTourist = await _touristRepository.CreateAsync(tourist);
            var bookExcursion = _mapper.Map<BookExcursion>(bookExcursionDto);
            var excursion = _excursionRepository.GetById(bookExcursion.ExcursionId);
            var days = (excursion.DepartureDate-excursion.ArrivalDate).Days;
            bookExcursion.TotalPrice = days*excursion.Price;
            savedTourist.AddReservation(bookExcursion);
           await _touristRepository.UpdateAsync(savedTourist);
        }

        public async Task<IEnumerable<BookExcursion>> ListReservesAsync()
        {
            var reserves = await _bookExcursionRepository.ListAsync();
            return reserves;
        }
    }
}