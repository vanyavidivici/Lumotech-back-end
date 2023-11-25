using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lumotech.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00199079-d8bf-4a49-9d7e-a89520813b12", null, "Manager", "MANAGER" },
                    { "1fbb87a7-39c7-4d59-abb7-75b1a77a2224", null, "Customer", "CUSTOMER" },
                    { "27d78f14-3479-4cf1-9911-fb3443adc8ff", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00199079-d8bf-4a49-9d7e-a89520813b12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fbb87a7-39c7-4d59-abb7-75b1a77a2224");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27d78f14-3479-4cf1-9911-fb3443adc8ff");
        }
    }
}
