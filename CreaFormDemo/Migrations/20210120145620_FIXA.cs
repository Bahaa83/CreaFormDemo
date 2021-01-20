using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class FIXA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Läkemedel_Allmänt_clientProfileID",
                table: "Läkemedel");

            migrationBuilder.RenameColumn(
                name: "clientProfileID",
                table: "Läkemedel",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Läkemedel_clientProfileID",
                table: "Läkemedel",
                newName: "IX_Läkemedel_ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Läkemedel_Klient_ClientID",
                table: "Läkemedel",
                column: "ClientID",
                principalTable: "Klient",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Läkemedel_Klient_ClientID",
                table: "Läkemedel");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Läkemedel",
                newName: "clientProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_Läkemedel_ClientID",
                table: "Läkemedel",
                newName: "IX_Läkemedel_clientProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Läkemedel_Allmänt_clientProfileID",
                table: "Läkemedel",
                column: "clientProfileID",
                principalTable: "Allmänt",
                principalColumn: "ID");
        }
    }
}
