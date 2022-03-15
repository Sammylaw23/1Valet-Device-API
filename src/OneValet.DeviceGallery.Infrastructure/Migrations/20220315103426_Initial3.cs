using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneValet.DeviceGallery.Infrastructure.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DeviceUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "DeviceUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "DeviceUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "DeviceUsers");
        }
    }
}
