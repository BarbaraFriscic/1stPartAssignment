using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehiclesAssignment.Server.Migrations
{
    /// <inheritdoc />
    public partial class VehiclesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "Id", "Abreviation", "Name" },
                values: new object[,]
                {
                    { 1, "ALFA", "Alfa Romeo" },
                    { 2, "CHEV", "Chevrolet" },
                    { 3, "HYUN", "Hyundai" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abreviation", "MakeID", "Name" },
                values: new object[,]
                {
                    { 1, "ALFA", 1, "031 Spider Roadsters" },
                    { 2, "CHEV", 2, "002 Impala/Caprice Belair" },
                    { 3, "HYUN", 3, "036 Accent GT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleMakes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleMakes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleMakes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
