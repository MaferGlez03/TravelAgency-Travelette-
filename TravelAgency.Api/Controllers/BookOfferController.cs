using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookOffer;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookOfferController : ControllerBase
    {
        private readonly ITouristService _touristService;
        private readonly IBookOfferService _bookOfferService;

        public BookOfferController(ITouristService touristService, IBookOfferService bookOfferService)
        {
            _touristService = touristService;
            _bookOfferService = bookOfferService;
        }

        [HttpPost]
        [Route("book")]
        [Authorize]
        public async Task<IActionResult> BookOffer(BookOfferDto bookOfferDto)
        {
            await _touristService.BookOfferAsync(bookOfferDto);
            return Ok();
        }

        [HttpPost]
        [Route("bookByAdmin")]
        [Authorize]
        public async Task<IActionResult> BookOfferByAdmin(BookOfferByAdminDto bookOfferDto)
        {
            await _bookOfferService.BookOfferByAdminAsync(bookOfferDto);
            return Ok();
        }
        [HttpGet]
        [Route("list")]
        [Authorize]
        public async Task<IActionResult> ListReserves([FromQuery]int pageNumber =1,[FromQuery] int pageSize= int.MaxValue)
        {
            var reserves = await _bookOfferService.ListReservesAsync(pageNumber,pageSize);
            return Ok(reserves);
        }
    }
}