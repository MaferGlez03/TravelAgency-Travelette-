using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookExcursion;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure.Identity;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookPackage;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface ITouristService
    {
        Task<Tourist> CreateTouristAsync(User touristDto);
        Task<Tourist> UpdateTouristAsync(Tourist touristDto);
        Task<IEnumerable<Tourist>> ListTouristAsync();
        Task DeleteTouristByIdAsync(int touristDto);
        Task BookOfferAsync(BookOfferDto bookOfferDto);
        Task BookPackageAsync(BookPackageDto bookPackageDto);
        Task BookExcursionAsync(BookExcursionDto bookExcursionDto);
    }
}