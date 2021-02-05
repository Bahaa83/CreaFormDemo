using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_clientSymptoms_SymtomCategoryID",
                table: "clientSymptoms",
                column: "SymtomCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_clientSymptoms_Symtom kategori_SymtomCategoryID",
                table: "clientSymptoms",
                column: "SymtomCategoryID",
                principalTable: "Symtom kategori",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientSymptoms_Symtom kategori_SymtomCategoryID",
                table: "clientSymptoms");

            migrationBuilder.DropIndex(
                name: "IX_clientSymptoms_SymtomCategoryID",
                table: "clientSymptoms");
        }
    }
}
