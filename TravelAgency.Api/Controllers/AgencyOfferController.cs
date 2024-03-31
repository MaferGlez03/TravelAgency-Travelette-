using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.ApplicationServices.IServices;

namespace TravelAgency.Api.Controllers
{
    public class AgencyOfferController:ControllerBase
    {
        private readonly IAgencyOfferService _agencyOfferService;

        public AgencyOfferController(IAgencyOfferService agencyOfferService)
        {
            _agencyOfferService = agencyOfferService;
        }

        [HttpPost]
        [Route("create")]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateAgencyOffer(int agencyId,int offerId, double price)
        {
            await  _agencyOfferService.CreateAgencyOfferAsync(agencyId,offerId,price);
            return Ok();

        }

        // [HttpGet]
        // [Route("list")]
        // //[Authorize (Roles = "SuperAdmin")]
        // public async Task<ActionResult<IEnumerable<Agency>>> ListAgency()
        // {
        //     var agencies = await _agencyService.ListAgencyAsync();

        //     return Ok(agencies);

        // }

        // // [HttpGet]
        // // [Route("find")]
        // // public async Task<IActionResult> FindAgency(Agency agency)
        // // {
        // //     var _agency = await _agencyContext.Agencies.FindAsync(agency.Id);

        // //     if (_agency == null) return NotFound();

        // //     return Ok(_agency);

        // // }

        // [HttpPut]
        // [Route("update")]
        // public async Task<ActionResult> UpdateAgency(AgencyDto agency)
        // {
        //     var _agency = await _agencyService.UpdateAgencyAsync(agency);
        //     return Ok(_agency);

        // }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> DeleteAgency(int agencyId, int offerId)
        {
            await _agencyOfferService.DeleteAgencyOfferByIdAsync(agencyId, offerId);
           return Ok();
        }
    }
}