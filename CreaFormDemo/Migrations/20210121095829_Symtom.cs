using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class Symtom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frekvens",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrekvensText = table.Column<string>(name: "Frekvens Text", type: "nvarchar(max)", nullable: true),
                    Värde = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frekvens", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Svårighet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Värde = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Svårighet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Symtom kategori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategorisnamn = table.Column<string>(name: "Kategoris namn", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symtom kategori", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Symtom Frågor ",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symtomtext = table.Column<string>(name: "Symtom text", type: "nvarchar(max)", nullable: true),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SymptomsCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symtom Frågor ", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Symtom Frågor _Symtom kategori_SymptomsCategoryID",
                        column: x => x.SymptomsCategoryID,
                        principalTable: "Symtom kategori",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Symtom Frågor _SymptomsCategoryID",
                table: "Symtom Frågor ",
                column: "SymptomsCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frekvens");

            migrationBuilder.DropTable(
                name: "Svårighet");

            migrationBuilder.DropTable(
                name: "Symtom Frågor ");

            migrationBuilder.DropTable(
                name: "Symtom kategori");
        }
    }
}
