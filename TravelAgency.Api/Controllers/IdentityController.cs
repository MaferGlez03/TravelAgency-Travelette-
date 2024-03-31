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
            return Ok(new
            {
                userId = result.Item2,
                token = result.Item1
            });
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogUser(LoginDto loginDto)
        {
            var user = await _identityService.CheckCredentialsAsync(loginDto);

             return Ok(new
            {
                verificstion = user.Item1,
                token = user.Item2
            });
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetUsers()
        {
            var users =_identityService.ListUsersAsync();
            return Ok(users);
        }

    }
}