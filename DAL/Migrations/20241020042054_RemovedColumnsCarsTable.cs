using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApplication.Migrations
{
    /// <inheritdoc />
    public partial class RemovedColumnsCarsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Drivetrain",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "ExtraMileageFee",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "FuelEfficiency",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HasMileageLimit",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HorsePower",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "IsPetFriendly",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "IsSmokingAllowed",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "MileageLimit",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "OwnerEmail",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "OwnerPhoneNumber",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Torque",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Trim",
                table: "CarDetails");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerAddress",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuelCapacity",
                table: "CarDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerAddress",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FuelCapacity",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Drivetrain",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraMileageFee",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FuelEfficiency",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasMileageLimit",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HorsePower",
                table: "CarDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPetFriendly",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSmokingAllowed",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MileageLimit",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerEmail",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerPhoneNumber",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Torque",
                table: "CarDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trim",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
