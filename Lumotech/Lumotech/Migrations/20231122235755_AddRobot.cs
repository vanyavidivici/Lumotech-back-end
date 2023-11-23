using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lumotech.Migrations
{
    /// <inheritdoc />
    public partial class AddRobot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Robots",
                columns: new[] { "RobotId", "GpsLatitude", "GpsLongitude", "RobotStationId", "SerialNumber", "TechnicalStatus" },
                values: new object[] { new Guid("1f3e9b74-abc1-48a7-901b-caf65e67e196"), null, null, new Guid("1aec523e-e4ef-4876-bb18-09526ad77e29"), "0000011", "Good" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Robots",
                keyColumn: "RobotId",
                keyValue: new Guid("1f3e9b74-abc1-48a7-901b-caf65e67e196"));
        }
    }
}
