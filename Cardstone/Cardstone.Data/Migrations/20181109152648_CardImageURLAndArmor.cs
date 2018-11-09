using Microsoft.EntityFrameworkCore.Migrations;

namespace Cardstone.Database.Migrations
{
    public partial class CardImageURLAndArmor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "25567afd-6006-4ed1-ba2e-a56ef4907bc4", "56b770bb-af36-4b8b-a52b-a9a28163eb2e" });

            migrationBuilder.AddColumn<int>(
                name: "Armor",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Cards",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "270029ea-7a6e-41c8-a38d-35258635780a", "5a3030bf-fbd3-4786-850b-ea65280599de", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "270029ea-7a6e-41c8-a38d-35258635780a", "5a3030bf-fbd3-4786-850b-ea65280599de" });

            migrationBuilder.DropColumn(
                name: "Armor",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Cards");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25567afd-6006-4ed1-ba2e-a56ef4907bc4", "56b770bb-af36-4b8b-a52b-a9a28163eb2e", "Admin", null });
        }
    }
}
