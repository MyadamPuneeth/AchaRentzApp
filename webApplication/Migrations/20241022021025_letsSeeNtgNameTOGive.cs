using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApplication.Migrations
{
    /// <inheritdoc />
    public partial class letsSeeNtgNameTOGive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentalDetails_CarId",
                table: "RentalDetails");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetails_CarId",
                table: "RentalDetails",
                column: "CarId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RentalDetails_CarId",
                table: "RentalDetails");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetails_CarId",
                table: "RentalDetails",
                column: "CarId");
        }
    }
}
