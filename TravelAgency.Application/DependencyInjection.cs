using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Services;
using TravelAgency.Application.Authentication;
using TravelAgency.Application.Interfaces;

namespace TravelAgency.Application
{
    public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services,ConfigurationManager configurationManager)
    {
            services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SECTION_NAME));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IAgencyService, AgencyService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<ITouristService, TouristService>();
            services.AddScoped<IFacilityService, FacilityService>();       
            services.AddScoped<ILodgingOfferService, LodgingOfferService>();
            services.AddScoped<IPackageService, PackageService>();       
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();       
    }
}
}