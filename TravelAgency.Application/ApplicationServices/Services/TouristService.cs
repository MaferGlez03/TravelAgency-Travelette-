using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookExcursion;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Security;
using TravelAgency.Application.Interfaces;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.DataAccess.IRepository;
using TravelAgency.Infrastructure.Identity;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookPackage;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class TouristService : ITouristService
    {
        private readonly IUser _user; 
        private readonly IAgencyOfferRepository _agencyOfferRepository;
        private readonly IExcursionRepository _excursionRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly ITouristRepository _touristRepository;
        private readonly IMapper _mapper;

        public TouristService(ITouristRepository touristRepository, IMapper mapper, IUser user, IAgencyOfferRepository agencyOfferRepository, IExcursionRepository excursionRepository, IPackageRepository packageRepository)
        {
            _touristRepository = touristRepository;
            _mapper = mapper;
            _user = user;
            _agencyOfferRepository = agencyOfferRepository;
            _excursionRepository = excursionRepository;
            _packageRepository = packageRepository;
        }
        public async Task<Tourist> CreateTouristAsync(User touristUser)
        {
            Tourist tourist = new();
            tourist.Nationality=touristUser.Nationality.ToString();
            tourist.Name=touristUser.UserName!;
            tourist.userId = touristUser.Id;

            await _touristRepository.CreateAsync(tourist);
            return _mapper.Map<Tourist>(tourist);
        }
       

         public async Task<IEnumerable<Tourist>> ListTouristAsync()
        {
            var tourists = await _touristRepository.ListAsync();
            var list = tourists.ToList();
            List <Tourist> touristsfinal = new();
            for (int i = 0; i < tourists.Count(); i++)
            {
                touristsfinal.Add(_mapper.Map<Tourist>(list[i]));
            }
            return touristsfinal;
        }

        public async Task<Tourist> UpdateTouristAsync(Tourist touristDto)
        {
            var tourist = _mapper.Map<Tourist>(touristDto);
            await _touristRepository.UpdateAsync(tourist);
            return _mapper.Map<Tourist>(tourist);
            
        }
         public async Task DeleteTouristByIdAsync(int touristDto)
        {
            await _touristRepository.DeleteByIdAsync(touristDto);
        }

        public async Task BookOfferAsync(BookOfferDto bookOfferDto)
        {
            var bookOffer = _mapper.Map<BookOffer>(bookOfferDto);
            var agencyOffer = _agencyOfferRepository.GetById(bookOffer.AgencyOfferId);
            var tourists = await _touristRepository.ListAsync();
            var tourist =tourists.ToList<Tourist>().FirstOrDefault(x=>x.userId == _user.Id)!;
            var days = (bookOfferDto.DepurateDate-bookOfferDto.ArrivalDate).Days;
            bookOffer.Price = days*agencyOffer.Price;
            tourist.AddReservation(bookOffer);
            await _touristRepository.UpdateAsync(tourist);          
        }
        public async Task BookPackageAsync(BookPackageDto bookPackageDto)
        {
            var bookPackage = _mapper.Map<BookPackage>(bookPackageDto);
            var Package = _packageRepository.GetById(bookPackage.PackageId);
            var tourists = await _touristRepository.ListAsync();
            var tourist =tourists.ToList<Tourist>().FirstOrDefault(x=>x.userId == _user.Id)!;
            bookPackage.Price = 200*Package.Price;
            tourist.AddReservation(bookPackage);
            await _touristRepository.UpdateAsync(tourist);          
        }
        public async Task BookExcursionAsync(BookExcursionDto bookExcursionDto)
        {
            var bookExcursion = _mapper.Map<BookExcursion>(bookExcursionDto);
            var excursion = _excursionRepository.GetById(bookExcursion.ExcursionId);
            var tourists = await _touristRepository.ListAsync();
            var tourist =tourists.ToList<Tourist>().FirstOrDefault(x=>x.userId == _user.Id)!;
            var days = (excursion.DepartureDate-excursion.ArrivalDate).Days;
            bookExcursion.TotalPrice = days*excursion.Price;
            tourist.AddReservation(bookExcursion);
            await _touristRepository.UpdateAsync(tourist);          
        }
    }
}