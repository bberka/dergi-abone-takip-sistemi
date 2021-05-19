using Microsoft.EntityFrameworkCore.Migrations;

namespace DAboneTakip.Migrations
{
    public partial class mg4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KayıtSuresi",
                table: "Aboneliklers",
                newName: "KayıtSuresiAy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KayıtSuresiAy",
                table: "Aboneliklers",
                newName: "KayıtSuresi");
        }
    }
}
