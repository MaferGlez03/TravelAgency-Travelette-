using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Hotel;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
           _hotelService=hotelService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateHotel(HotelDto hotel)
        {
            await _hotelService.CreateHotelAsync(hotel);
            return Ok();

        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<Hotel>>> ListHotel()
        {
            var agencies = await _hotelService.ListHotelAsync();

            return Ok(agencies);

        }

        // [HttpGet]
        // [Route("find")]
        // public async Task<IActionResult> FindHotel(Hotel hotel)
        // {
        //     var _hotel = await _hotelContext.Agencies.FindAsync(hotel.Id);

        //     if (_hotel == null) return NotFound();

        //     return Ok(_hotel);

        // }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateHotel(HotelDto hotel)
        {
            var _hotel = await _hotelService.UpdateHotelAsync(hotel);
            return Ok(_hotel);

        }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> DeleteHotel(int hotel)
        {
             await _hotelService.DeleteHotelByIdAsync(hotel);
           return Ok();
        }
        // public async Task<IActionResult> DeleteHotel(HotelDto hotel)
        // {
        //     System.Console.WriteLine("Entro al controller");
        //     _hotelService.DeleteHotelAsync(hotel);
        //     return Ok();

        // }
    }


}