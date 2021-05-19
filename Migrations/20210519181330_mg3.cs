using Microsoft.EntityFrameworkCore.Migrations;

namespace DAboneTakip.Migrations
{
    public partial class mg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AylikUcret",
                table: "Aboneliklers",
                newName: "ToplamUcret");

            migrationBuilder.AddColumn<int>(
                name: "KayıtSuresiGun",
                table: "Aboneliklers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KayıtSuresiGun",
                table: "Aboneliklers");

            migrationBuilder.RenameColumn(
                name: "ToplamUcret",
                table: "Aboneliklers",
                newName: "AylikUcret");
        }
    }
}
