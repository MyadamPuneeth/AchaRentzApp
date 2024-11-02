﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApplication.Migrations
{
    /// <inheritdoc />
    public partial class addedNewNumberOfTripsColumnInCarsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfTrips",
                table: "CarDetails",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
