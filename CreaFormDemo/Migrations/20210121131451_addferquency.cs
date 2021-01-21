using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class addferquency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SymptomQuestionsID",
                table: "Svårighet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SymptomQuestionsID",
                table: "Frekvens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Svårighet_SymptomQuestionsID",
                table: "Svårighet",
                column: "SymptomQuestionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Frekvens_SymptomQuestionsID",
                table: "Frekvens",
                column: "SymptomQuestionsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Frekvens_Symtom Frågor _SymptomQuestionsID",
                table: "Frekvens",
                column: "SymptomQuestionsID",
                principalTable: "Symtom Frågor ",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Svårighet_Symtom Frågor _SymptomQuestionsID",
                table: "Svårighet",
                column: "SymptomQuestionsID",
                principalTable: "Symtom Frågor ",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frekvens_Symtom Frågor _SymptomQuestionsID",
                table: "Frekvens");

            migrationBuilder.DropForeignKey(
                name: "FK_Svårighet_Symtom Frågor _SymptomQuestionsID",
                table: "Svårighet");

            migrationBuilder.DropIndex(
                name: "IX_Svårighet_SymptomQuestionsID",
                table: "Svårighet");

            migrationBuilder.DropIndex(
                name: "IX_Frekvens_SymptomQuestionsID",
                table: "Frekvens");

            migrationBuilder.DropColumn(
                name: "SymptomQuestionsID",
                table: "Svårighet");

            migrationBuilder.DropColumn(
                name: "SymptomQuestionsID",
                table: "Frekvens");
        }
    }
}
