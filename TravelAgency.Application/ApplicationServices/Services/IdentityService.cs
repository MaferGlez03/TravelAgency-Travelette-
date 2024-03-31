using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Maps.Dtos.Security;
using TravelAgency.Application.Interfaces;
using TravelAgency.Domain.Constant;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Application.ApplicationServices.Services
{
    public class IdentityService : IIdentityService
    {

        private readonly ITouristService _touristService;
        private readonly IIdentityManager _identityManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;
        public IdentityService(IJwtTokenGenerator jwtTokenGenerator, IIdentityManager identityManager, IMapper mapper, ITouristService touristService)
        {
            _touristService = touristService;
            _identityManager = identityManager;
            _mapper = mapper;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<(bool, string)> CheckCredentialsAsync(LoginDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            if (user == null) return (false, "");
            var savedUser = await _identityManager.CheckCredentialsAsync(user.UserName!, userDto.Password);
            if (savedUser)
            {
                var userId = _identityManager.ListUsersAsync().FirstOrDefault(x => x.UserName == user.UserName)!.Id;
                var adminRole = await _identityManager.IsInRoleAsync(userId, Role.Admin);
                var superAdminRole = await _identityManager.IsInRoleAsync(userId, Role.SuperAdmin);
                var touristRole = await _identityManager.IsInRoleAsync(userId, Role.Tourist);

                if (adminRole)
                {
                    var token = _jwtTokenGenerator.GenerateToken(user, Role.Admin);
                    return (savedUser, token);
                }
                else if (superAdminRole)
                {
                    var token = _jwtTokenGenerator.GenerateToken(user, Role.SuperAdmin);
                    return (savedUser, token);
                }
                else
                {
                    var token = _jwtTokenGenerator.GenerateToken(user, Role.Tourist);
                    return (savedUser, token);
                }

            }
            return (false, "Your credentials are incorrect");
        }

        public async Task<(string,string)> CreateUserAsync(RegisterDto userDto)
        {
           
            var user = _mapper.Map<User>(userDto);
            var savedUser = await _identityManager.CreateUserAsync(user, userDto.Password);
            await _identityManager.AddRoles(savedUser.Id, userDto.role);
            await _touristService.CreateTouristAsync(savedUser);
            var token = _jwtTokenGenerator.GenerateToken(savedUser, userDto.role);
            return (token, savedUser.Id.ToString());
        }

        public  IEnumerable<User> ListUsersAsync()
        {
            var users =  _identityManager.ListUsersAsync();
            return users;
        }
    }
}