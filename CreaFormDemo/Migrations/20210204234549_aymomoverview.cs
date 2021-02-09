using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class aymomoverview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "symtomOverviews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    SymtomCategoryID = table.Column<int>(type: "int", nullable: false),
                    TotalFrequency = table.Column<int>(type: "int", nullable: false),
                    TotalDifficulty = table.Column<int>(type: "int", nullable: false),
                    TotPsymtom = table.Column<int>(type: "int", nullable: false),
                    totalNumberofsymptoms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_symtomOverviews", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "symtomOverviews");
        }
    }
}
