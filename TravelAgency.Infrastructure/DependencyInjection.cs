using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelAgency.Infrastructure.DataAccess.IRepository;
using TravelAgency.Infrastructure.DataAccess.Repository;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Infrastructure
{

    public static class DependencyInjection
    {
        public static void AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var db = services.AddDbContext<TravelAgencyContext>(x =>
                    { x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); });
            services.AddScoped<IIdentityManager, IdentityManager>();
            services.AddScoped<IAgencyRepository, AgencyRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<ITouristRepository, TouristRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<ILodgingOfferRepository, LodgingOfferRepository>();
            services.AddScoped<IAgencyOfferRepository, AgencyOfferRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPackageFacilityRepository, PackageFacilityRepository>();
            services.AddScoped<IExcursionRepository, ExcursionRepository>();
            services.AddScoped<IExtendedExcursionRepository, ExtendedExcursionRepository>();            
            services.AddScoped<IBookOfferRepository, BookOfferRepository>();
            services.AddScoped<IHotel_ExtendedExcursionRepository, Hotel_ExtendedExcursionRepository>();
            services.AddScoped<IBookExcursionRepository, BookExcursionRepository>();
            services.AddScoped<IBookPackageRepository, BookPackageRepository>();
            services.AddScoped<TravelAgencyContextInitializer>();

            services.AddAuthentication();

            services
            .AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<TravelAgencyContext>();
    
        }
    }    
}

