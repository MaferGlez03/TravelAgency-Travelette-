using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Constant;


namespace TravelAgency.Application.ApplicationServices.Maps.Dtos.Security
{
    public class RegisterDto : UserDto
    {
        public string Password { get; set; }
        
        [DefaultValue(Role.Tourist)]
        public string role{get; set;} 
    }
}