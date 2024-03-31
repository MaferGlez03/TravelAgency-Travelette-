using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Facility;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService _facilityService;
        public FacilityController(IFacilityService facilityService)
        {
           _facilityService=facilityService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateFacility(FacilityDto facility)
        {
            await _facilityService.CreateFacilityAsync(facility);
            return Ok();

        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<Facility>>> ListFacility()
        {
            var facilities = await _facilityService.ListFacilityAsync();

            return Ok(facilities);

        }

        // [HttpGet]
        // [Route("find")]
        // public async Task<IActionResult> FindFacility(Facility facility)
        // {
        //     var _facility = await _facilityContext.Facilities.FindAsync(facility.Id);

        //     if (_facility == null) return NotFound();

        //     return Ok(_facility);

        // }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateFacility(FacilityDto facility)
        {
            var _facility = await _facilityService.UpdateFacilityAsync(facility);
            return Ok(_facility);

        }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> DeleteFacility(int facility)
        {
            await _facilityService.DeleteFacilityAsync(facility);
           return Ok();
        }
        // public async Task<IActionResult> DeleteFacility(FacilityDto facility)
        // {
        //     System.Console.WriteLine("Entro al controller");
        //     _facilityService.DeleteFacilityAsync(facility);
        //     return Ok();

        // }
    }


}