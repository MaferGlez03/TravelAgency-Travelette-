using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.BookPackage;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookPackageController : ControllerBase
    {
         private readonly ITouristService _touristService;
        private readonly IBookPackageService _bookPackageService;

        public BookPackageController(ITouristService touristService, IBookPackageService bookPackageService)
        {
            _touristService = touristService;
             _bookPackageService =  bookPackageService;
        }

        [HttpPost]
        [Route("book")]
        [Authorize]
        public async Task<IActionResult> BookExcursion(BookPackageDto bookPackageDto)
        {
            await _touristService.BookPackageAsync(bookPackageDto);
            return Ok();
        }

        [HttpPost]
        [Route("bookByAdmin")]
        [Authorize]
        public async Task<IActionResult> BookExcursionByAdmin(BookPackageByAdminDto bookPackageDto)
        {
            await _bookPackageService.BookPackageByAdminAsync(bookPackageDto);
            return Ok();
        }
    }
}