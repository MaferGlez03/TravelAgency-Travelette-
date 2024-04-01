using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Hotel_ExtendedExcursions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate1",
                table: "Excursions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hotel_ExtendedExcursions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false),
                    ExtendedExcursion_Id = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    ExtendedExcursionId = table.Column<int>(type: "int", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel_ExtendedExcursions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_ExtendedExcursions_Excursions_ExtendedExcursionId",
                        column: x => x.ExtendedExcursionId,
                        principalTable: "Excursions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hotel_ExtendedExcursions_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_ExtendedExcursions_ExtendedExcursionId",
                table: "Hotel_ExtendedExcursions",
                column: "ExtendedExcursionId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_ExtendedExcursions_HotelId",
                table: "Hotel_ExtendedExcursions",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel_ExtendedExcursions");

            migrationBuilder.DropColumn(
                name: "ArrivalDate1",
                table: "Excursions");
        }
    }
}
