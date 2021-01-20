using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class REMOVECLIENTMEDCINE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientMedicines");

            migrationBuilder.AddColumn<int>(
                name: "clientProfileID",
                table: "Läkemedel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Läkemedel_clientProfileID",
                table: "Läkemedel",
                column: "clientProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Läkemedel_Allmänt_clientProfileID",
                table: "Läkemedel",
                column: "clientProfileID",
                principalTable: "Allmänt",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Läkemedel_Allmänt_clientProfileID",
                table: "Läkemedel");

            migrationBuilder.DropIndex(
                name: "IX_Läkemedel_clientProfileID",
                table: "Läkemedel");

            migrationBuilder.DropColumn(
                name: "clientProfileID",
                table: "Läkemedel");

            migrationBuilder.CreateTable(
                name: "clientMedicines",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    MedicineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientMedicines", x => new { x.ClientID, x.MedicineID });
                    table.ForeignKey(
                        name: "FK_clientMedicines_Klient_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Klient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clientMedicines_Läkemedel_MedicineID",
                        column: x => x.MedicineID,
                        principalTable: "Läkemedel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clientMedicines_MedicineID",
                table: "clientMedicines",
                column: "MedicineID");
        }
    }
}
