using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApplication.Migrations
{
    /// <inheritdoc />
    public partial class addColumnsInCarsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InsuranceNumber",
                table: "CarDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Mileage",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "CarDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfDays",
                table: "CarDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RcNumber",
                table: "CarDetails",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
