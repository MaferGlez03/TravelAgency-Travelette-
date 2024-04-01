using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BookExcursion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDate1",
                table: "Excursions");

            migrationBuilder.CreateTable(
                name: "BookExcursions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExcursionId = table.Column<int>(type: "int", nullable: false),
                    TouristId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    NumberOfCompanions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookExcursions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookExcursions_Excursions_ExcursionId",
                        column: x => x.ExcursionId,
                        principalTable: "Excursions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookExcursions_Tourists_TouristId",
                        column: x => x.TouristId,
                        principalTable: "Tourists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookExcursions_ExcursionId",
                table: "BookExcursions",
                column: "ExcursionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookExcursions_TouristId",
                table: "BookExcursions",
                column: "TouristId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookExcursions");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate1",
                table: "Excursions",
                type: "datetime2",
                nullable: true);
        }
    }
}
