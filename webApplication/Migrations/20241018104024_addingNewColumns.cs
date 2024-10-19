using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApplication.Migrations
{
    /// <inheritdoc />
    public partial class addingNewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelYear",
                table: "CarDetails",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelYear",
                table: "CarDetails");
        }
    }
}
