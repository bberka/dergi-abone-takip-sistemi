using Microsoft.EntityFrameworkCore.Migrations;

namespace DAboneTakip.Migrations.DergiDb
{
    public partial class alter4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UyelerUyeID",
                table: "Dergilers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dergilers_UyelerUyeID",
                table: "Dergilers",
                column: "UyelerUyeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dergilers_Uyelers_UyelerUyeID",
                table: "Dergilers",
                column: "UyelerUyeID",
                principalTable: "Uyelers",
                principalColumn: "UyeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dergilers_Uyelers_UyelerUyeID",
                table: "Dergilers");

            migrationBuilder.DropIndex(
                name: "IX_Dergilers_UyelerUyeID",
                table: "Dergilers");

            migrationBuilder.DropColumn(
                name: "UyelerUyeID",
                table: "Dergilers");
        }
    }
}
