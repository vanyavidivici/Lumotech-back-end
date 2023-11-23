using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lumotech.Migrations
{
    /// <inheritdoc />
    public partial class AddLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "City", "Country" },
                values: new object[] { new Guid("7d95a214-b50c-4ad3-8d06-15787d1db8f9"), "Berlin", "Germany" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("7d95a214-b50c-4ad3-8d06-15787d1db8f9"));
        }
    }
}
