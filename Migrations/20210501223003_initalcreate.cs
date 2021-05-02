using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAboneTakip.Migrations
{
    public partial class initalcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAD = table.Column<string>(type: "Varchar(16)", nullable: true),
                    Sifre = table.Column<string>(type: "Varchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorilers",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAD = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
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
                    UyeAD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    DergiAD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DergiTARIH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    UyelerUyeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dergilers", x => x.DergiID);
                    table.ForeignKey(
                        name: "FK_Dergilers_Kategorilers_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategorilers",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dergilers_Uyelers_UyelerUyeID",
                        column: x => x.UyelerUyeID,
                        principalTable: "Uyelers",
                        principalColumn: "UyeID",
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
                name: "IX_Dergilers_KategoriID",
                table: "Dergilers",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Dergilers_UyelerUyeID",
                table: "Dergilers",
                column: "UyelerUyeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aboneliklers");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Dergilers");

            migrationBuilder.DropTable(
                name: "Kategorilers");

            migrationBuilder.DropTable(
                name: "Uyelers");
        }
    }
}
