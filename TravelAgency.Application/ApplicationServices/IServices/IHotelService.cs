using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IHotelService
    {
        Task<HotelDto> CreateHotelAsync(HotelDto hotelDto);
        Task<HotelDto> UpdateHotelAsync(HotelDto hotelDto);
        Task<PaginatedList<HotelResponseDto>> ListHotelAsync(int pageNumber,int pageSize);
        Task DeleteHotelByIdAsync(int hotelDto);
    }
}