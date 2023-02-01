using Microsoft.EntityFrameworkCore.Migrations;

namespace PolandDelivery.Migrations
{
    public partial class ForServicesBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ForServicesBlock",
                table: "Menus",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForServicesBlock",
                table: "Menus");
        }
    }
}
