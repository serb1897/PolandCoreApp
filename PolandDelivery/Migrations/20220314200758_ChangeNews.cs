using Microsoft.EntityFrameworkCore.Migrations;

namespace PolandDelivery.Migrations
{
    public partial class ChangeNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentShort",
                table: "NewsContents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentShort",
                table: "NewsContents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
