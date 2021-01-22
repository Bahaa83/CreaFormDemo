using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class addwellbeing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Välbefinnande - uppskattning",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Totalt = table.Column<int>(type: "int", nullable: false),
                    Fysiskt = table.Column<int>(type: "int", nullable: false),
                    Mentaltkognitivt = table.Column<int>(name: "Mentalt/kognitivt", type: "int", nullable: false),
                    Känslomässigt = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Välbefinnande - uppskattning", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Välbefinnande - uppskattning_Klient_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Klient",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Välbefinnande - uppskattning_ClientID",
                table: "Välbefinnande - uppskattning",
                column: "ClientID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Välbefinnande - uppskattning");
        }
    }
}
