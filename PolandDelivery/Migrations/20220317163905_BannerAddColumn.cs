using Microsoft.EntityFrameworkCore.Migrations;

namespace PolandDelivery.Migrations
{
    public partial class BannerAddColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeadImageMobile",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadImageMobile",
                table: "Banners");
        }
    }
}
