using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApplication.Migrations
{
    /// <inheritdoc />
    public partial class remodeledCarsTaberu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RtoCertificate",
                table: "CarDetails");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "CarDetails",
                newName: "Trim");

            migrationBuilder.RenameColumn(
                name: "PurchasedYear",
                table: "CarDetails",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "PricePerDay",
                table: "CarDetails",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "NoOfDays",
                table: "CarDetails",
                newName: "Torque");

            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "CarDetails",
                newName: "SeatingCapacity");

            migrationBuilder.RenameColumn(
                name: "ModelYear",
                table: "CarDetails",
                newName: "NumberOfDoors");

            migrationBuilder.RenameColumn(
                name: "ManYear",
                table: "CarDetails",
                newName: "MinimumRentalPeriod");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CarDetails",
                newName: "Transmission");

            migrationBuilder.RenameColumn(
                name: "CarName",
                table: "CarDetails",
                newName: "RentalLocation");

            migrationBuilder.RenameColumn(
                name: "CarModel",
                table: "CarDetails",
                newName: "RegistrationState");

            migrationBuilder.RenameColumn(
                name: "CarLicensePlate",
                table: "CarDetails",
                newName: "OwnerPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "CarCompany",
                table: "CarDetails",
                newName: "OwnerName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "CarDetails",
                newName: "OwnerEmail");

            migrationBuilder.AlterColumn<long>(
                name: "RcNumber",
                table: "CarDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceNumber",
                table: "CarDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableFrom",
                table: "CarDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableUntil",
                table: "CarDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DistanceFromUser",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Drivetrain",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineType",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraMileageFee",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FuelCapacity",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FuelEfficiency",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasAirConditioning",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasBackupCamera",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasBluetooth",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasChildSeat",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasGPS",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasHeatedSeats",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasMileageLimit",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HomeDeliveryAvailable",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HorsePower",
                table: "CarDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsuranceExpiryDate",
                table: "CarDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InsuranceIncluded",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceProvider",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "CarDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOutOfStateAllowed",
                table: "CarDetails",
                type: "bit",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "LastServicedDate",
                table: "CarDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicensePlate",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MileageLimit",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerAddress",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "CarDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RentalPricePerDay",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UserRating",
                table: "CarDetails",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableFrom",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "AvailableUntil",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "DistanceFromUser",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Drivetrain",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "EngineType",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "ExtraMileageFee",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "FuelCapacity",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "FuelEfficiency",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HasAirConditioning",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HasBackupCamera",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HasBluetooth",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HasChildSeat",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HasGPS",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HasHeatedSeats",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HasMileageLimit",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HomeDeliveryAvailable",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "HorsePower",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "InsuranceExpiryDate",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "InsuranceIncluded",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "InsuranceProvider",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "IsOutOfStateAllowed",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "IsPetFriendly",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "IsSmokingAllowed",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "LastServicedDate",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "MileageLimit",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "OwnerAddress",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "RentalPricePerDay",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "CarDetails");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "CarDetails",
                newName: "PurchasedYear");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "CarDetails",
                newName: "PricePerDay");

            migrationBuilder.RenameColumn(
                name: "Trim",
                table: "CarDetails",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Transmission",
                table: "CarDetails",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Torque",
                table: "CarDetails",
                newName: "NoOfDays");

            migrationBuilder.RenameColumn(
                name: "SeatingCapacity",
                table: "CarDetails",
                newName: "MyProperty");

            migrationBuilder.RenameColumn(
                name: "RentalLocation",
                table: "CarDetails",
                newName: "CarName");

            migrationBuilder.RenameColumn(
                name: "RegistrationState",
                table: "CarDetails",
                newName: "CarModel");

            migrationBuilder.RenameColumn(
                name: "OwnerPhoneNumber",
                table: "CarDetails",
                newName: "CarLicensePlate");

            migrationBuilder.RenameColumn(
                name: "OwnerName",
                table: "CarDetails",
                newName: "CarCompany");

            migrationBuilder.RenameColumn(
                name: "OwnerEmail",
                table: "CarDetails",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "NumberOfDoors",
                table: "CarDetails",
                newName: "ModelYear");

            migrationBuilder.RenameColumn(
                name: "MinimumRentalPeriod",
                table: "CarDetails",
                newName: "ManYear");

            migrationBuilder.AlterColumn<long>(
                name: "RcNumber",
                table: "CarDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "InsuranceNumber",
                table: "CarDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "RtoCertificate",
                table: "CarDetails",
                type: "bigint",
                nullable: true);
        }
    }
}
