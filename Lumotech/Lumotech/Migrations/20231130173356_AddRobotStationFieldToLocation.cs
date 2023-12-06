using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lumotech.Migrations
{
    /// <inheritdoc />
    public partial class AddRobotStationFieldToLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a5af7ce-2db8-43b9-a901-d78bedd4d392");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63c610a6-604f-4d3a-9a5b-9f7e34a8b8ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65621801-4cdd-4cd2-a386-82f9bb663ea1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15bf418e-58ea-46b4-ab05-42f87a4e859c", null, "Administrator", "ADMINISTRATOR" },
                    { "ab3c6ed0-d19a-4a23-8be0-558681bc6bda", null, "Customer", "CUSTOMER" },
                    { "f1b3b3ce-921a-43e7-aed8-68cf234d399b", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15bf418e-58ea-46b4-ab05-42f87a4e859c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab3c6ed0-d19a-4a23-8be0-558681bc6bda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1b3b3ce-921a-43e7-aed8-68cf234d399b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a5af7ce-2db8-43b9-a901-d78bedd4d392", null, "Manager", "MANAGER" },
                    { "63c610a6-604f-4d3a-9a5b-9f7e34a8b8ea", null, "Administrator", "ADMINISTRATOR" },
                    { "65621801-4cdd-4cd2-a386-82f9bb663ea1", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
