using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lumotech.Migrations
{
    /// <inheritdoc />
    public partial class EditedCarEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlateNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BatteryCapacity",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0342cee5-3b5d-48aa-81aa-8e2857653790", null, "Customer", "CUSTOMER" },
                    { "19e6e5de-e33a-485b-adfc-d7855eee8c2d", null, "Administrator", "ADMINISTRATOR" },
                    { "5dc3a590-1a2d-4845-9e64-4381afb36375", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "BatteryCapacity", "CarModel", "PlateNumber", "SerialNumber", "UserId" },
                values: new object[] { new Guid("0f4c011c-a92f-42de-8343-165fc07926d6"), 100.0, "Tesla Model X", "AA2030AA", "VD9485445KD", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0342cee5-3b5d-48aa-81aa-8e2857653790");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19e6e5de-e33a-485b-adfc-d7855eee8c2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dc3a590-1a2d-4845-9e64-4381afb36375");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: new Guid("0f4c011c-a92f-42de-8343-165fc07926d6"));

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PlateNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BatteryCapacity",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00189397-c53e-4403-b7c6-3e66503f4993", null, "Manager", "MANAGER" },
                    { "1925ed63-4d07-4958-959a-8977882a49ef", null, "Administrator", "ADMINISTRATOR" },
                    { "d356c434-acf0-49eb-a7b4-5637de582b86", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "BatteryCapacity", "CarModel", "PlateNumber", "SerialNumber", "UserId" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "100.0", "Tesla Model X", "AA2030AA", "VD9485445KD", null });
        }
    }
}
