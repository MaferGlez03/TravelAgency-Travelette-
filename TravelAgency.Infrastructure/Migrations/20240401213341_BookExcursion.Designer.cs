﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAgency.Infrastructure;

#nullable disable

namespace TravelAgency.Infrastructure.Migrations
{
    [DbContext(typeof(TravelAgencyContext))]
    [Migration("20240401213341_BookExcursion")]
    partial class BookExcursion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Agency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElectronicAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Agencies");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Excursion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgencyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ArrivalPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeparturePlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Guia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AgencyID");

                    b.ToTable("Excursions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Excursion");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.LodgingOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Availability")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("Id", "HotelId")
                        .IsUnique();

                    b.ToTable("LodgingOffers");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgencyID")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AgencyID");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.PackageFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.HasIndex("PackageId");

                    b.ToTable("PackagesFacilities");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Tourist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Tourists");
                });

            modelBuilder.Entity("TravelAgency.Domain.Relations.AgencyOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgencyId")
                        .HasColumnType("int");

                    b.Property<int>("LodgingOfferId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LodgingOfferId");

                    b.HasIndex("AgencyId", "LodgingOfferId")
                        .IsUnique();

                    b.ToTable("AgencyOffers");
                });

            modelBuilder.Entity("TravelAgency.Domain.Relations.BookExcursion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExcursionId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfCompanions")
                        .HasColumnType("int");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<int>("TouristId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExcursionId");

                    b.HasIndex("TouristId");

                    b.ToTable("BookExcursions");
                });

            modelBuilder.Entity("TravelAgency.Domain.Relations.BookOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgencyOfferId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepurateDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TouristId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgencyOfferId");

                    b.HasIndex("TouristId");

                    b.ToTable("BookOffers");
                });

            modelBuilder.Entity("TravelAgency.Domain.Relations.Hotel_ExtendedExcursion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExtendedExcursionId")
                        .HasColumnType("int");

                    b.Property<int>("ExtendedExcursion_Id")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("Hotel_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExtendedExcursionId");

                    b.HasIndex("HotelId");

                    b.ToTable("Hotel_ExtendedExcursions");
                });

            modelBuilder.Entity("TravelAgency.Infrastructure.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Nationality")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.ExtendedExcursion", b =>
                {
                    b.HasBaseType("TravelAgency.Domain.Entities.Excursion");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ExtendedExcursion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TravelAgency.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TravelAgency.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TravelAgency.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Excursion", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Agency", "agency")
                        .WithMany("Excursions")
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("agency");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.LodgingOffer", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Hotel", "Hotel")
                        .WithMany("lodgingOffers")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Package", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Agency", "agency")
                        .WithMany("Packages")
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("agency");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.PackageFacility", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Facility", "facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.Package", "package")
                        .WithMany("packageFacilities")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("facility");

                    b.Navigation("package");
                });

            modelBuilder.Entity("TravelAgency.Domain.Relations.AgencyOffer", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Agency", "Agency")
                        .WithMany("AgencyOffers")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.LodgingOffer", "LodgingOffer")
                        .WithMany("AgencyOffers")
                        .HasForeignKey("LodgingOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");

                    b.Navigation("LodgingOffer");
                });

            modelBuilder.Entity("TravelAgency.Domain.Relations.BookExcursion", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Excursion", "Excursion")
                        .WithMany("BookExcursions")
                        .HasForeignKey("ExcursionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.Tourist", "Tourist")
                        .WithMany("BookExcursions")
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excursion");

                    b.Navigation("Tourist");
                });

            modelBuilder.Entity("TravelAgency.Domain.Relations.BookOffer", b =>
                {
                    b.HasOne("TravelAgency.Domain.Relations.AgencyOffer", "AgencyOffer")
                        .WithMany("BookOffers")
                        .HasForeignKey("AgencyOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.Tourist", "Tourist")
                        .WithMany("BookOffers")
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgencyOffer");

                    b.Navigation("Tourist");
                });

            modelBuilder.Entity("TravelAgency.Domain.Relations.Hotel_ExtendedExcursion", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.ExtendedExcursion", "ExtendedExcursion")
                        .WithMany("Hotel_ExtendedExcursions")
                        .HasForeignKey("ExtendedExcursionId");

                    b.HasOne("TravelAgency.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Hotel_ExtendedExcursions")
                        .HasForeignKey("HotelId");

                    b.Navigation("ExtendedExcursion");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Agency", b =>
                {
                    b.Navigation("AgencyOffers");

                    b.Navigation("Excursions");

                    b.Navigation("Packages");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Excursion", b =>
                {
                    b.Navigation("BookExcursions");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("Hotel_ExtendedExcursions");

                    b.Navigation("lodgingOffers");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.LodgingOffer", b =>
                {
                    b.Navigation("AgencyOffers");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Package", b =>
                {
                    b.Navigation("packageFacilities");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Tourist", b =>
                {
                    b.Navigation("BookExcursions");

                    b.Navigation("BookOffers");
                });

            modelBuilder.Entity("TravelAgency.Domain.Relations.AgencyOffer", b =>
                {
                    b.Navigation("BookOffers");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.ExtendedExcursion", b =>
                {
                    b.Navigation("Hotel_ExtendedExcursions");
                });
#pragma warning restore 612, 618
        }
    }
}
