using Microsoft.EntityFrameworkCore.Migrations;

namespace PolandDelivery.Migrations
{
    public partial class AddServicesIcons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlackIconUrl",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhiteIconUrl",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlackIconUrl",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "WhiteIconUrl",
                table: "Menus");
        }
    }
}
