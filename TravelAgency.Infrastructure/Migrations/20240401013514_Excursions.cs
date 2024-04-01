using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Excursions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyID",
                table: "Excursions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Excursions_AgencyID",
                table: "Excursions",
                column: "AgencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Excursions_Agencies_AgencyID",
                table: "Excursions",
                column: "AgencyID",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excursions_Agencies_AgencyID",
                table: "Excursions");

            migrationBuilder.DropIndex(
                name: "IX_Excursions_AgencyID",
                table: "Excursions");

            migrationBuilder.DropColumn(
                name: "AgencyID",
                table: "Excursions");
        }
    }
}
