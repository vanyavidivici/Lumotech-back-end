using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lumotech.Migrations
{
    /// <inheritdoc />
    public partial class InitialCarData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "BatteryCapacity", "CarModel", "PlateNumber", "SerialNumber", "UserId" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "100.0", "Tesla Model X", "AA2030AA", "VD9485445KD", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
