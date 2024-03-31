using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Security;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUser(RegisterDto registerDto)
        {

            var result = await _identityService.CreateUserAsync(registerDto);
            //return Ok(result.Item1);
            return Ok(new {
                userId = result.Item1,
                token = result.Item2
            });
        }

        
           [HttpPost]
            [Route("login")]
        public async Task<IActionResult> LogUser(LoginDto loginDto)
        {
            var user = await _identityService.CheckCredentialsAsync(loginDto);

            return Ok(user.Item2);
        }
    }
}