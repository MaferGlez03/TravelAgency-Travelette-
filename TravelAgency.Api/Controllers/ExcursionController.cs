using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Excursion;
using TravelAgency.Domain.Entities;
using TravelAgency.Infrastructure;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExcursionController : ControllerBase
    {
        private readonly IExcursionService _excursionService;
        public ExcursionController(IExcursionService excursionService)
        {
           _excursionService=excursionService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateExcursion(ExcursionDto excursion)
        {
            await _excursionService.CreateExcursionAsync(excursion);
            return Ok();

        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<Excursion>>> ListExcursion()
        {
            var excursions = await _excursionService.ListExcursionAsync();

            return Ok(excursions);

        }

        // [HttpGet]
        // [Route("find")]
        // public async Task<IActionResult> FindExcursion(Excursion excursion)
        // {
        //     var _excursion = await _excursionContext.Excursions.FindAsync(excursion.Id);

        //     if (_excursion == null) return NotFound();

        //     return Ok(_excursion);

        // }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateExcursion(ExcursionDto excursion)
        {
            var _excursion = await _excursionService.UpdateExcursionAsync(excursion);
            return Ok(_excursion);

        }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> DeleteExcursion(int excursion)
        {
             _excursionService.DeleteExcursionAsync(excursion);
           return Ok();
        }
        // public async Task<IActionResult> DeleteExcursion(ExcursionDto excursion)
        // {
        //     System.Console.WriteLine("Entro al controller");
        //     _excursionService.DeleteExcursionAsync(excursion);
        //     return Ok();

        // }
    }


}