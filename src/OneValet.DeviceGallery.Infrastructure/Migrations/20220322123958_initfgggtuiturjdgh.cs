using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneValet.DeviceGallery.Infrastructure.Migrations
{
    public partial class initfgggtuiturjdgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemperatureC = table.Column<double>(type: "float", nullable: false),
                    IconBase64String = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.DeviceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DeviceUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceUsers", x => x.Id);
                });

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
                table: "DeviceUsers",
                columns: new[] { "Id", "Email", "EmailConfirmed", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 1, "onevalet@gmail.com", false, "One", "Valet", "sapass123$", "onevalet" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "DeviceTypeId", "IconBase64String", "IsOnline", "Name", "TemperatureC" },
                values: new object[,]
                {
                    { 1, 1, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", true, "Nokia 7 Plus", 49.0 },
                    { 2, 2, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", false, "iPad 11", 67.0 },
                    { 3, 3, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", false, "HP Elitebook", 72.0 },
                    { 4, 2, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", false, "Samsung Tablet", 31.0 },
                    { 5, 3, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", false, "DELL 205", 55.0 },
                    { 6, 1, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", false, "Tecno Spark 6", 84.0 },
                    { 7, 1, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", true, "iPhone 13 Pro Max", 50.0 },
                    { 8, 1, "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh", false, "Nokia 3310", 37.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropTable(
                name: "DeviceUsers");
        }
    }
}
