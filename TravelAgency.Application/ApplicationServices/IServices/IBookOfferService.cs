using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookOffer;
using TravelAgency.Domain.Relations;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IBookOfferService
    {
        Task BookOfferByAdminAsync(BookOfferByAdminDto bookOfferDto);
        Task<IEnumerable<BookOffer>> ListReservesAsync();
    }
}