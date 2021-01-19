using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class addNameInlivsstiltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Livs stil område",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Livs stil område");
        }
    }
}
