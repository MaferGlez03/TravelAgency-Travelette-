using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookPackage;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Domain.Relations;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IBookPackageService
    {
        Task BookPackageByAdminAsync(BookPackageByAdminDto bookPackageDto);
        Task<PaginatedList<BookPackage>> ListReservesAsync(int pageNumber,int pageSize);
    }
}