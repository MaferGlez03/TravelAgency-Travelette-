using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TravelAgency.Domain.Constant;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Infrastructure
{
    public static class InitializerExtensions
    {
        public static async Task InitializeDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initializer = scope.ServiceProvider.GetRequiredService<TravelAgencyContextInitializer>();

            await initializer.InitializeAsync();

            await initializer.SeedAsync();
        }
    }
    public class TravelAgencyContextInitializer
    {
        private readonly ILogger<TravelAgencyContextInitializer> _logger;
        private readonly TravelAgencyContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TravelAgencyContextInitializer(ILogger<TravelAgencyContextInitializer> logger, TravelAgencyContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            //Default Role
            var superadminRole = new IdentityRole(Role.SuperAdmin);
            var touristRole = new IdentityRole(Role.Tourist);

            if (_roleManager.Roles.All(r => r.Name != superadminRole.Name))
            {
                await _roleManager.CreateAsync(superadminRole);
            }
            if (_roleManager.Roles.All(r => r.Name != touristRole.Name))
            {
                await _roleManager.CreateAsync(touristRole);
            }

            //Default User
            var superadmin = new User { UserName = "SuperAdmin", Email = "superadmin@localhost" };

            if (_userManager.Users.All(u => u.UserName != superadmin.UserName))
            {
                await _userManager.CreateAsync(superadmin, "Superadminpassword1*");
                if (!string.IsNullOrWhiteSpace(superadminRole.Name))
                {
                    await _userManager.AddToRolesAsync(superadmin, new[] { superadminRole.Name });
                }
            }
            //!Also we can define here default data.
        }
    }
}