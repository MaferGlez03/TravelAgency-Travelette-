using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.FrequentTourist;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Package;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
         private readonly IStatisticsService _statisticsService;
        public StatisticsController(IPackageService packageService, IStatisticsService statisticsService)
        {
           _statisticsService = statisticsService;
        }

        [HttpGet]
        [Route("list_spensives_packages")]
        public async Task<ActionResult<IEnumerable<PackageResponseDto>>> ListSpensivesPackage([FromQuery]int pageNumber =1,[FromQuery] int pageSize= int.MaxValue)
        {
            var packages = await _statisticsService.SpensivesPackageAsync(pageNumber,pageSize);

            return Ok(packages);
        }

        [HttpGet]
        [Route("list_weekend_excursions")]
        public async Task<ActionResult<IEnumerable<PackageResponseDto>>> ListWeekendExcursions([FromQuery]int pageNumber =1,[FromQuery] int pageSize= int.MaxValue)
        {
            var weekend_excursions = await _statisticsService.WeekendExcursions(pageNumber,pageSize);

            return Ok(weekend_excursions);
        }
        [HttpGet]
        [Route("list_hotels_packages")]
        public async Task<ActionResult<IEnumerable<PackageResponseDto>>> ListHotelPackages([FromQuery]int pageNumber =1,[FromQuery] int pageSize= int.MaxValue)
        {
            var weekend_excursions = await _statisticsService.HotelPackages(pageNumber,pageSize);

            return Ok(weekend_excursions);
        }

        [HttpGet]
        [Route("list_frequent_tourists")]
        public async Task<ActionResult<IEnumerable<FrequentTouristDto>>> ListFrequentTourists([FromQuery]int pageNumber =1,[FromQuery] int pageSize= int.MaxValue)
        {
            var frequent_tourists = await _statisticsService.FrequentTourists(pageNumber,pageSize);

            return Ok(frequent_tourists);
        }
    }
}