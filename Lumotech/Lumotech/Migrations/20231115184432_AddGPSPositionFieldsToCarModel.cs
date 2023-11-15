using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lumotech.Migrations
{
    /// <inheritdoc />
    public partial class AddGPSPositionFieldsToCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GpsLatitude",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GpsLongitude",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "GpsLatitude", "GpsLongitude" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GpsLatitude",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GpsLongitude",
                table: "Cars");
        }
    }
}
