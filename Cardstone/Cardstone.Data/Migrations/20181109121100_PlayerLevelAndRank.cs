using Microsoft.EntityFrameworkCore.Migrations;

namespace Cardstone.Database.Migrations
{
    public partial class PlayerLevelAndRank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "247aae81-2ab5-46dc-9c16-0b0943e0f006", "eae1db1f-d594-4155-a528-b4ee675e9079" });

            migrationBuilder.AddColumn<int>(
                name: "LeaderboardRank",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25567afd-6006-4ed1-ba2e-a56ef4907bc4", "56b770bb-af36-4b8b-a52b-a9a28163eb2e", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "25567afd-6006-4ed1-ba2e-a56ef4907bc4", "56b770bb-af36-4b8b-a52b-a9a28163eb2e" });

            migrationBuilder.DropColumn(
                name: "LeaderboardRank",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "247aae81-2ab5-46dc-9c16-0b0943e0f006", "eae1db1f-d594-4155-a528-b4ee675e9079", "Admin", null });
        }
    }
}
