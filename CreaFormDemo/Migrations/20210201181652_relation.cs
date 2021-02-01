using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_clientSymptoms_ClientID",
                table: "clientSymptoms");

            migrationBuilder.CreateIndex(
                name: "IX_clientSymptoms_ClientID",
                table: "clientSymptoms",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_clientSymptoms_ClientID",
                table: "clientSymptoms");

            migrationBuilder.CreateIndex(
                name: "IX_clientSymptoms_ClientID",
                table: "clientSymptoms",
                column: "ClientID",
                unique: true);
        }
    }
}
