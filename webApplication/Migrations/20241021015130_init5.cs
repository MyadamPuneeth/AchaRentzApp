using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApplication.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerAddress",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FAQs",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainImageUrl",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reviews",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnails",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "FAQs",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "MainImageUrl",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Reviews",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Thumbnails",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Username",
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
        }
    }
}
