using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Security;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IIdentityService
    {
        Task<string> CreateUserAsync(RegisterDto userDto);
        Task<bool> CheckCredentialsAsync(LoginDto userDto);
    }
}