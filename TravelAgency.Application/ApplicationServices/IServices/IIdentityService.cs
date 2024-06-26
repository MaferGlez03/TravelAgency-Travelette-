using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Security;
using TravelAgency.Application.Common.PaginatedList;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Application.ApplicationServices.IServices
{
    public interface IIdentityService
    {
        Task<(string,string)> CreateUserAsync(RegisterDto userDto);
        Task<(bool, string)> CheckCredentialsAsync(LoginDto userDto);
        PaginatedList<User> ListUsersAsync(int pageNumber,int pageSize);
    }
}