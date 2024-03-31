using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.ExtendedExcursion;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExtendedExcursionController : ControllerBase
    {
        private readonly IExtendedExcursionService _extendedExtendedExcursionService;
        public ExtendedExcursionController(IExtendedExcursionService extendedExtendedExcursionService)
        {
           _extendedExtendedExcursionService=extendedExtendedExcursionService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateExtendedExcursion(ExtendedExcursionDto extendedExtendedExcursion)
        {
            await _extendedExtendedExcursionService.CreateExtendedExcursionAsync(extendedExtendedExcursion);
            return Ok();

        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<ExtendedExcursion>>> ListExtendedExcursion()
        {
            var extendedExtendedExcursions = await _extendedExtendedExcursionService.ListExtendedExcursionAsync();

            return Ok(extendedExtendedExcursions);

        }

        // [HttpGet]
        // [Route("find")]
        // public async Task<IActionResult> FindExtendedExcursion(ExtendedExcursion extendedExtendedExcursion)
        // {
        //     var _extendedExtendedExcursion = await _extendedExtendedExcursionContext.ExtendedExcursions.FindAsync(extendedExtendedExcursion.Id);

        //     if (_extendedExtendedExcursion == null) return NotFound();

        //     return Ok(_extendedExtendedExcursion);

        // }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateExtendedExcursion(ExtendedExcursionDto extendedExtendedExcursion)
        {
            var _extendedExtendedExcursion = await _extendedExtendedExcursionService.UpdateExtendedExcursionAsync(extendedExtendedExcursion);
            return Ok(_extendedExtendedExcursion);

        }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> DeleteExtendedExcursion(int extendedExtendedExcursion)
        {
             _extendedExtendedExcursionService.DeleteExtendedExcursionAsync(extendedExtendedExcursion);
           return Ok();
        }
        // public async Task<IActionResult> DeleteExtendedExcursion(ExtendedExcursionDto extendedExtendedExcursion)
        // {
        //     System.Console.WriteLine("Entro al controller");
        //     _extendedExtendedExcursionService.DeleteExtendedExcursionAsync(extendedExtendedExcursion);
        //     return Ok();

        // }
    }


}