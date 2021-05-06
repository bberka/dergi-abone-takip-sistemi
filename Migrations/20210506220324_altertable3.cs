using Microsoft.EntityFrameworkCore.Migrations;

namespace DAboneTakip.Migrations
{
    public partial class altertable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "DergilerDergiID",
                table: "Uyelers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uyelers_DergilerDergiID",
                table: "Uyelers",
                column: "DergilerDergiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Uyelers_Dergilers_DergilerDergiID",
                table: "Uyelers",
                column: "DergilerDergiID",
                principalTable: "Dergilers",
                principalColumn: "DergiID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uyelers_Dergilers_DergilerDergiID",
                table: "Uyelers");

            migrationBuilder.DropIndex(
                name: "IX_Uyelers_DergilerDergiID",
                table: "Uyelers");

            migrationBuilder.DropColumn(
                name: "DergilerDergiID",
                table: "Uyelers");

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
    }
}
