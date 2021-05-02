using Microsoft.EntityFrameworkCore.Migrations;

namespace DAboneTakip.Migrations
{
    public partial class mg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sifre",
                table: "Admins",
                type: "Varchar(16)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Varchar(16)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAD",
                table: "Admins",
                type: "Varchar(16)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Varchar(16)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Admins",
                type: "Varchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "Sifre",
                table: "Admins",
                type: "Varchar(16)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(16)");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAD",
                table: "Admins",
                type: "Varchar(16)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(16)");
        }
    }
}
