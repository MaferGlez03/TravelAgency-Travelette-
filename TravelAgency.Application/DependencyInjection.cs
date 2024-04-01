using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Application.ApplicationServices.IServices;
using TravelAgency.Application.ApplicationServices.Services;
using TravelAgency.Application.Authentication;
using TravelAgency.Application.Interfaces;

namespace TravelAgency.Application
{
    public static class DependencyInjection
{
    
        public static void AddApplicationServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
            services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SECTION_NAME));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IAgencyService, AgencyService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<ITouristService, TouristService>();
            services.AddScoped<IFacilityService, FacilityService>();       
            services.AddScoped<ILodgingOfferService, LodgingOfferService>();
            services.AddScoped<IExcursionService, ExcursionService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IExtendedExcursionService, ExtendedExcursionService>();   
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();       
            services.AddScoped<IBookOfferService, BookOfferService>();
            services.AddScoped<IBookExcursionService, BookExcursionService>();
            

            //JwtToken configuration.
            services.AddAuthentication(options =>
           {
               options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           }).AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateActor = true,
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   RequireExpirationTime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = configurationManager.GetSection("JwtSettings:Issuer").Value,
                   ValidAudience = configurationManager.GetSection("JwtSettings:Audience").Value,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager.GetSection("JwtSettings:Secret").Value!))
               };
           });
    }
}
}