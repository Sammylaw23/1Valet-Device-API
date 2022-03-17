using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneValet.DeviceGallery.Infrastructure.Migrations
{
    public partial class addUser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeviceTypes",
                columns: new[] { "DeviceTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A pocket-sized device", "Phone" },
                    { 2, "A palm-sized device", "Tablet" },
                    { 3, "A personal computer", "PC" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "IconBase64String", "Name", "Online", "Status", "TemperatureC" },
                values: new object[,]
                {
                    { 1, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", "Nokia 7 Plus", true, "Offline", 49.0 },
                    { 2, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", "iPad 11", false, "Offline", 67.0 },
                    { 3, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", "HP Elitebook", false, "Offline", 72.0 },
                    { 4, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", "Samsung Tablet", false, "Offline", 31.0 },
                    { 5, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", "DELL 205", false, "Offline", 55.0 },
                    { 6, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", "Tecno Spark 6", false, "Offline", 84.0 },
                    { 7, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", "iPhone 13 Pro Max", true, "Offline", 50.0 },
                    { 8, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", "Nokia 3310", false, "Offline", 37.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "DeviceTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "DeviceTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeviceTypes",
                keyColumn: "DeviceTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
