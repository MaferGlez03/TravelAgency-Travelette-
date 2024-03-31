using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Package;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
         private readonly IPackageService _packageService;
        public PackageController(IPackageService packageService)
        {
           _packageService= packageService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePackage(PackageDto package)
        {
            await _packageService.CreatePackageAsync(package);
            return Ok();

        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<Package>>> ListPackage()
        {
            var packages = await _packageService.ListPackageAsync();

            return Ok(packages);

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
        public async Task<ActionResult> UpdatePackage(PackageDto package)
        {
            var _package = await _packageService.UpdatePackageAsync(package);
            return Ok(_package);

        }

        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> DeletePackage(int packageId)
        {
            await _packageService.DeletePackageByIdAsync(packageId);
           return Ok();
        }
    }
}