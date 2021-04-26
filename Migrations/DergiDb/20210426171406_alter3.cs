using Microsoft.EntityFrameworkCore.Migrations;

namespace DAboneTakip.Migrations.DergiDb
{
    public partial class alter3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aboneliklers_Dergilers_DergiID",
                table: "Aboneliklers");

            migrationBuilder.DropForeignKey(
                name: "FK_Aboneliklers_Uyelers_UyeID",
                table: "Aboneliklers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dergilers_Kategorilers_KategoriID",
                table: "Dergilers");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "Dergilers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UyeID",
                table: "Aboneliklers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DergiID",
                table: "Aboneliklers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aboneliklers_Dergilers_DergiID",
                table: "Aboneliklers",
                column: "DergiID",
                principalTable: "Dergilers",
                principalColumn: "DergiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aboneliklers_Uyelers_UyeID",
                table: "Aboneliklers",
                column: "UyeID",
                principalTable: "Uyelers",
                principalColumn: "UyeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dergilers_Kategorilers_KategoriID",
                table: "Dergilers",
                column: "KategoriID",
                principalTable: "Kategorilers",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aboneliklers_Dergilers_DergiID",
                table: "Aboneliklers");

            migrationBuilder.DropForeignKey(
                name: "FK_Aboneliklers_Uyelers_UyeID",
                table: "Aboneliklers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dergilers_Kategorilers_KategoriID",
                table: "Dergilers");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "Dergilers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UyeID",
                table: "Aboneliklers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DergiID",
                table: "Aboneliklers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Aboneliklers_Dergilers_DergiID",
                table: "Aboneliklers",
                column: "DergiID",
                principalTable: "Dergilers",
                principalColumn: "DergiID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aboneliklers_Uyelers_UyeID",
                table: "Aboneliklers",
                column: "UyeID",
                principalTable: "Uyelers",
                principalColumn: "UyeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dergilers_Kategorilers_KategoriID",
                table: "Dergilers",
                column: "KategoriID",
                principalTable: "Kategorilers",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
