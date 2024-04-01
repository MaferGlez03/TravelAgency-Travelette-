using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookExcursion;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookExcursionController : ControllerBase
    {
        private readonly ITouristService _touristService;
        private readonly IBookExcursionService _bookExcursionService;

        public BookExcursionController(ITouristService touristService, IBookExcursionService bookExcursionService)
        {
            _touristService = touristService;
            _bookExcursionService = bookExcursionService;
        }

        [HttpPost]
        [Route("book")]
        [Authorize]
        public async Task<IActionResult> BookExcursion(BookExcursionDto bookExcursionDto)
        {
            await _touristService.BookExcursionAsync(bookExcursionDto);
            return Ok();
        }

        [HttpPost]
        [Route("bookByAdmin")]
        [Authorize]
        public async Task<IActionResult> BookExcursionByAdmin(BookExcursionByAdminDto bookExcursionDto)
        {
            await _bookExcursionService.BookExcursionByAdminAsync(bookExcursionDto);
            return Ok();
        }
        [HttpGet]
        [Route("list")]
        [Authorize]
        public async Task<IActionResult> ListReserves()
        {
            var reserves = await _bookExcursionService.ListReservesAsync();
            return Ok(reserves);
        }
    }
}