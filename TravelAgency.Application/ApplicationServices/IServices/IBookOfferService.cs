using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookOffer;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Domain.Relations;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IBookOfferService
    {
        Task BookOfferByAdminAsync(BookOfferByAdminDto bookPackageDto);
        Task<PaginatedList<BookOffer>> ListReservesAsync(int pageNumber,int pageSize);
    }
}