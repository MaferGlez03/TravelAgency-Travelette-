using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelAgency.Infrastructure.DataAccess.IRepository;
using TravelAgency.Infrastructure.DataAccess.Repository;
using TravelAgency.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure
{

    public static class DependencyInjection
    {
        public static void AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var db = services.AddDbContext<TravelAgencyContext>(x =>
                    { x
                    //.UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")); });
            services.AddScoped<IIdentityManager, IdentityManager>();
            services.AddScoped<IAgencyRepository, AgencyRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<ITouristRepository, TouristRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<ILodgingOfferRepository, LodgingOfferRepository>();
            services.AddScoped<IExcursionRepository, ExcursionRepository>();
            services.AddScoped<IAgencyOfferRepository, AgencyOfferRepository>();
            services.AddScoped<IBookOfferRepository, BookOfferRepository>();
            services.AddScoped<TravelAgencyContextInitializer>();

           services
            .AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<TravelAgencyContext>();
    
        }
    }
    
}

