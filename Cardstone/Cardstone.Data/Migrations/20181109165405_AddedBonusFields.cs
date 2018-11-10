using Microsoft.EntityFrameworkCore.Migrations;

namespace Cardstone.Database.Migrations
{
    public partial class AddedBonusFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c5682aa8-fa58-47dc-809b-22932ef8d502", "fee755f0-c1f4-4174-8a25-6e4367f1bf31" });

            migrationBuilder.AddColumn<int>(
                name: "Armor",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cards",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddc6aa9a-67f1-4b20-a31f-e842f3a39051", "533b87f8-1209-47af-b2ae-1dece71aface", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ddc6aa9a-67f1-4b20-a31f-e842f3a39051", "533b87f8-1209-47af-b2ae-1dece71aface" });

            migrationBuilder.DropColumn(
                name: "Armor",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cards");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5682aa8-fa58-47dc-809b-22932ef8d502", "fee755f0-c1f4-4174-8a25-6e4367f1bf31", "Admin", null });
        }
    }
}
