using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Nationality;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalityController : ControllerBase
    {
        //!Añadir Get y cambiar el dto de registrarse.
        [HttpGet]
        public IActionResult GetNationalities()
        {
            var nationalities = Enum.GetValues(typeof(Nationality))
            .Cast<Nationality>()
            .Select(valor => new NationalityDto{Id = (int)valor, Name = valor.ToString()})
            .ToList();

            return Ok(nationalities);
        }
    }
}