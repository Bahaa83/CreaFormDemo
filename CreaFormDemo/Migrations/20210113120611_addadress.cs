using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class addadress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Addres",
                table: "Rådgivare",
                newName: "Ort");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Klient",
                newName: "Ort");

            migrationBuilder.AddColumn<string>(
                name: "Gatuadressr",
                table: "Rådgivare",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Postnummer",
                table: "Rådgivare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gatuadress",
                table: "Klient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Postnummer",
                table: "Klient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gatuadressr",
                table: "Rådgivare");

            migrationBuilder.DropColumn(
                name: "Postnummer",
                table: "Rådgivare");

            migrationBuilder.DropColumn(
                name: "Gatuadress",
                table: "Klient");

            migrationBuilder.DropColumn(
                name: "Postnummer",
                table: "Klient");

            migrationBuilder.RenameColumn(
                name: "Ort",
                table: "Rådgivare",
                newName: "Addres");

            migrationBuilder.RenameColumn(
                name: "Ort",
                table: "Klient",
                newName: "Address");
        }
    }
}
