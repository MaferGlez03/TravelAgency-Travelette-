using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.LodgingOffer;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LodgingOfferController : ControllerBase
    {
         private readonly ILodgingOfferService _lodgingOfferService;
        public LodgingOfferController(ILodgingOfferService lodgingOfferService)
        {
           _lodgingOfferService=lodgingOfferService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateLodgingOffer(LodgingOfferDto lodgingOffer)
        {
            await _lodgingOfferService.CreateLodgingOfferAsync(lodgingOffer);
            return Ok();

        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<LodgingOffer>>> ListLodgingOffer()
        {
            var lodgingOffers = await _lodgingOfferService.ListLodgingOfferAsync();

            return Ok(lodgingOffers);

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
        public async Task<ActionResult> UpdateLodgingOffer(LodgingOfferDto lodgingOffer)
        {
            var _lodgingOffer = await _lodgingOfferService.UpdateLodgingOfferAsync(lodgingOffer);
            return Ok(_lodgingOffer);

        }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> DeleteLodgingOffer(int lodgingOfferId)
        {
            await _lodgingOfferService.DeleteLodgingOfferByIdAsync(lodgingOfferId);
           return Ok();
        }
    }
}