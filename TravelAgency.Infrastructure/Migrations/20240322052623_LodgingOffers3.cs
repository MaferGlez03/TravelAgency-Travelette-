using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LodgingOffers3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoteId",
                table: "LodgingOffers",
                newName: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_LodgingOffers_HotelId",
                table: "LodgingOffers",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_LodgingOffers_Hotels_HotelId",
                table: "LodgingOffers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LodgingOffers_Hotels_HotelId",
                table: "LodgingOffers");

            migrationBuilder.DropIndex(
                name: "IX_LodgingOffers_HotelId",
                table: "LodgingOffers");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "LodgingOffers",
                newName: "HoteId");
        }
    }
}
