using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookPackage;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Application.Interfaces;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.DataAccess.IRepository;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class BookPackageService : IBookPackageService
    {
        private readonly IUser _user;
        private readonly IAgencyOfferRepository _agencyOfferRepository;
        private readonly IBookPackageRepository _bookPackageRepository;
        private readonly IPackageRepository _PackageRepository;
        private readonly ITouristRepository _touristRepository;
        private readonly IMapper _mapper;

        public BookPackageService(IAgencyOfferRepository agencyOfferRepository, ITouristRepository touristRepository, IUser user, IMapper mapper, IBookPackageRepository bookPackageRepository, IPackageRepository packageRepository)
        {
            _agencyOfferRepository = agencyOfferRepository;
            _touristRepository = touristRepository;
            _user = user;
            _mapper = mapper;
            _bookPackageRepository = bookPackageRepository;
            _PackageRepository = packageRepository;
        }
        public async Task BookPackageByAdminAsync(BookPackageByAdminDto bookPackageDto)
        {
            var nationality = bookPackageDto.Nacionality;
            Nationality nationality1 = 0;
            var mappedNationality = _mapper.Map(nationality, nationality1);
            var tourist = new Domain.Entities.Tourist
            {
                Name = bookPackageDto.UserName,
                Nationality = mappedNationality.ToString(),
                userId = _user.Id!,
                Email=bookPackageDto.Email
            };
            var savedTourist = await _touristRepository.CreateAsync(tourist);
            var bookPackage = _mapper.Map<BookPackage>(bookPackageDto);
            var package = _PackageRepository.GetById(bookPackage.PackageId);
            bookPackage.Price = 200 * package.Price;
            savedTourist.AddReservation(bookPackage);
            await _touristRepository.UpdateAsync(savedTourist);
        }

        public Task<PaginatedList<BookPackage>> ListReservesAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}