using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lumotech.Migrations
{
    /// <inheritdoc />
    public partial class EditedCarUserRobotEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "GpsLatitude",
                table: "Robots");

            migrationBuilder.DropColumn(
                name: "GpsLongitude",
                table: "Robots");

            migrationBuilder.DropColumn(
                name: "GpsLatitude",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GpsLongitude",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00189397-c53e-4403-b7c6-3e66503f4993", null, "Manager", "MANAGER" },
                    { "1925ed63-4d07-4958-959a-8977882a49ef", null, "Administrator", "ADMINISTRATOR" },
                    { "d356c434-acf0-49eb-a7b4-5637de582b86", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00189397-c53e-4403-b7c6-3e66503f4993");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1925ed63-4d07-4958-959a-8977882a49ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d356c434-acf0-49eb-a7b4-5637de582b86");

            migrationBuilder.AddColumn<string>(
                name: "GpsLatitude",
                table: "Robots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GpsLongitude",
                table: "Robots",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15bf418e-58ea-46b4-ab05-42f87a4e859c", null, "Administrator", "ADMINISTRATOR" },
                    { "ab3c6ed0-d19a-4a23-8be0-558681bc6bda", null, "Customer", "CUSTOMER" },
                    { "f1b3b3ce-921a-43e7-aed8-68cf234d399b", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "GpsLatitude", "GpsLongitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Robots",
                keyColumn: "RobotId",
                keyValue: new Guid("1f3e9b74-abc1-48a7-901b-caf65e67e196"),
                columns: new[] { "GpsLatitude", "GpsLongitude" },
                values: new object[] { null, null });
        }
    }
}
