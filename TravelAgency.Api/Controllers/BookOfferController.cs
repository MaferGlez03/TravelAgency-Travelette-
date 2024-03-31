using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookOffer;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookOfferController : ControllerBase
    {
        private readonly ITouristService _touristService;

        public BookOfferController(ITouristService touristService)
        {
            _touristService = touristService;
        }

        [HttpPost]
        [Route("book")]
        [Authorize]
        public async Task<IActionResult> BookOffer(BookOfferDto bookOfferDto)
        {
            await _touristService.BookOfferAsync(bookOfferDto);
            return Ok();
        }
    }
}