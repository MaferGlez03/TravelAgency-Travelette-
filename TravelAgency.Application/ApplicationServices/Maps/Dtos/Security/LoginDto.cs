using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.Security
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}