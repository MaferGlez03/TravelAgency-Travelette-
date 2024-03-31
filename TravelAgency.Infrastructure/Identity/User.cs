using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace TravelAgency.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        public Nationality Nationality{get; set;}
    }
}