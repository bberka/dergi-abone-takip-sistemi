using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAboneTakip.Migrations.DergiDb
{
    public partial class DergiDbMg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorilers",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorilers", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Uyelers",
                columns: table => new
                {
                    UyeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<long>(type: "bigint", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyelers", x => x.UyeID);
                });

            migrationBuilder.CreateTable(
                name: "Dergilers",
                columns: table => new
                {
                    DergiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DergiAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DergiTARIH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    KategorilerKategoriID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dergilers", x => x.DergiID);
                    table.ForeignKey(
                        name: "FK_Dergilers_Kategorilers_KategorilerKategoriID",
                        column: x => x.KategorilerKategoriID,
                        principalTable: "Kategorilers",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aboneliklers",
                columns: table => new
                {
                    KayıtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KayıtTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KayıtSuresi = table.Column<int>(type: "int", nullable: false),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    DergiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aboneliklers", x => x.KayıtID);
                    table.ForeignKey(
                        name: "FK_Aboneliklers_Dergilers_DergiID",
                        column: x => x.DergiID,
                        principalTable: "Dergilers",
                        principalColumn: "DergiID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aboneliklers_Uyelers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "Uyelers",
                        principalColumn: "UyeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aboneliklers_DergiID",
                table: "Aboneliklers",
                column: "DergiID");

            migrationBuilder.CreateIndex(
                name: "IX_Aboneliklers_UyeID",
                table: "Aboneliklers",
                column: "UyeID");

            migrationBuilder.CreateIndex(
                name: "IX_Dergilers_KategorilerKategoriID",
                table: "Dergilers",
                column: "KategorilerKategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aboneliklers");

            migrationBuilder.DropTable(
                name: "Dergilers");

            migrationBuilder.DropTable(
                name: "Uyelers");

            migrationBuilder.DropTable(
                name: "Kategorilers");
        }
    }
}
