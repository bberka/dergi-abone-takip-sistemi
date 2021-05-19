using Microsoft.EntityFrameworkCore.Migrations;

namespace DAboneTakip.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AylikUcret",
                table: "Dergilers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AylikUcret",
                table: "Aboneliklers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AylikUcret",
                table: "Dergilers");

            migrationBuilder.DropColumn(
                name: "AylikUcret",
                table: "Aboneliklers");
        }
    }
}
