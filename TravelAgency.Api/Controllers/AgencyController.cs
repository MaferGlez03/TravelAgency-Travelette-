using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.AddOffer;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Agency;
using TravelAgency.Domain.Constant;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure;
using TravelAgency.Infrastructure.DataAccess.Filters;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgencyController : ControllerBase
    {
        private readonly IAgencyService _agencyService;
        public AgencyController(IAgencyService agencyService)
        {
           _agencyService=agencyService;
        }

        [HttpPost]
        [Route("create")]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateAgency(AgencyDto agency)
        {
           var agency2 = await _agencyService.CreateAgencyAsync(agency);
            return Ok(agency2);

        }

        [HttpGet]
        [Route("list")]
        //[Authorize (Roles = "SuperAdmin")]
        public async Task<ActionResult<IEnumerable<Agency>>> ListAgency([FromQuery]int pageNumber =1,[FromQuery] int pageSize= int.MaxValue)
        {
            var agencies = await _agencyService.ListAgencyAsync(pageNumber,pageSize);

            return Ok(agencies);

        }

        [HttpGet]
        [Route("list/filters")]
         public async Task<ActionResult<IEnumerable<Agency>>> ListAgencyFilters([FromQuery]AgencyFilters? filters,
         [FromQuery] int pageSize = int.MaxValue,
         [FromQuery] int pageNumber = 1)
        {
            var agencies = await _agencyService.FindAllAgenciesAsync(filters,pageNumber,pageSize);

            return Ok(agencies);

        }

        // [HttpGet]
        // [Route("find")]
        // public async Task<IActionResult> FindAgency(Agency agency)
        // {
        //     var _agency = await _agencyContext.Agencies.FindAsync(agency.Id);

        //     if (_agency == null) return NotFound();

        //     return Ok(_agency);

        // }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateAgency(AgencyDto agency)
        {
            var _agency = await _agencyService.UpdateAgencyAsync(agency);
            return Ok(_agency);

        }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> DeleteAgency(int agencyId)
        {
            await _agencyService.DeleteAgencyByIdAsync(agencyId);
           return Ok();
        }

        [HttpPost]
        [Route("addoffer")]

        public async Task<IActionResult> AddOffersAgency(AddOfferDto addOfferDto)
        {
            await _agencyService.AddOffers(addOfferDto);
           return Ok();
        }

        [HttpDelete]
        [Route("deleteoffer")]

        public async Task<IActionResult> DeleteOffersAgency(int agencyofferId)
        {
            await _agencyService.DeleteOffers(agencyofferId);
           return Ok();
        }
       
    }


}