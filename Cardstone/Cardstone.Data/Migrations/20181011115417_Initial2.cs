using Microsoft.EntityFrameworkCore.Migrations;

namespace Cardstone.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "XpWin",
                table: "Combats",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XpWin",
                table: "Combats");
        }
    }
}
