using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.Identity;

namespace TravelAgency.Infrastructure
{
    public class TravelAgencyContext : IdentityDbContext<User>
    {
        public TravelAgencyContext(DbContextOptions options) : base(options)
        {

        }
        //Create an instance to be mapped as a table.
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<LodgingOffer> LodgingOffers { get; set; }
        public DbSet<AgencyOffer> AgencyOffers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageFacility> PackagesFacilities { get; set; }
        public DbSet<Excursion> Excursions { get; set; }
        public DbSet<ExtendedExcursion> ExtendedExcursions { get; set; }
        public DbSet<Hotel_ExtendedExcursion> Hotel_ExtendedExcursions { get; set; }
        public DbSet<BookExcursion> BookExcursions {get; set;}        
        public DbSet<Hotel_ExtendedExcursion> HotelExtendedExcursions { get; set; }

        public DbSet<BookOffer> BookOffers { get; set; }
        public DbSet<BookPackage> BookPackages { get; set; }

        //Override the method to make each Agency's name, Hotel's name and Facility's name unique.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Here we can add other restrictions if needed.
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agency>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Hotel>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Facility>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Tourist>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<AgencyOffer>().HasIndex(key => new { key.AgencyId, key.LodgingOfferId }).IsUnique();
            //         modelBuilder.Entity<AgencyOffer>()
            // .HasOne(ao => ao.LodgingOffer)
            // .WithMany(lo => lo.AgencyOffers)
            // .HasForeignKey(ao => ao.LodgingOfferId)
            // .HasPrincipalKey(lo => lo.Id);
            modelBuilder.Entity<LodgingOffer>().HasIndex(key => new { key.Id, key.HotelId }).IsUnique();
            modelBuilder.Entity<Package>()
            .HasMany(p => p.PackageExtendedExcursions)
            .WithOne(pee => pee.Package)
            .HasForeignKey(pee => pee.PackageId)
            .OnDelete(DeleteBehavior.NoAction); // Evita el problema de múltiples caminos de cascada

        }
    }
}