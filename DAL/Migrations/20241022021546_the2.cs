using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApplication.Migrations
{
    /// <inheritdoc />
    public partial class the2 : Migration
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
                column: "CarId");
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
                column: "CarId",
                unique: true);
        }
    }
}
