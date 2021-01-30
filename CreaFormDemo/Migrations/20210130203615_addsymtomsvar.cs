using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class addsymtomsvar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientSymptoms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    SymtomText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SymtomCategoryID = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientSymptoms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_clientSymptoms_Klient_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Klient",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_clientSymptoms_ClientID",
                table: "clientSymptoms",
                column: "ClientID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientSymptoms");
        }
    }
}
