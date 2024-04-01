using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookExcursion;
using TravelAgency.Domain.Relations;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IBookExcursionService
    {
        Task BookExcursionByAdminAsync(BookExcursionByAdminDto bookExcursionDto);
        Task<IEnumerable<BookExcursion>> ListReservesAsync();
    }
}