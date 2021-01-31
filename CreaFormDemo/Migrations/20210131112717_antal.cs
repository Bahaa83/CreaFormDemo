using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class antal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Frequency",
                table: "clientSymptoms",
                newName: "Frekvens");

            migrationBuilder.RenameColumn(
                name: "Difficulty",
                table: "clientSymptoms",
                newName: "Svårighet");

            migrationBuilder.AddColumn<int>(
                name: "Antal symtom",
                table: "clientSymptoms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Totalpoäng/symtom",
                table: "clientSymptoms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Antal symtom",
                table: "clientSymptoms");

            migrationBuilder.DropColumn(
                name: "Totalpoäng/symtom",
                table: "clientSymptoms");

            migrationBuilder.RenameColumn(
                name: "Svårighet",
                table: "clientSymptoms",
                newName: "Difficulty");

            migrationBuilder.RenameColumn(
                name: "Frekvens",
                table: "clientSymptoms",
                newName: "Frequency");
        }
    }
}
