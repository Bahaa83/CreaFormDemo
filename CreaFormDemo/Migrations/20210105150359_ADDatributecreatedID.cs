using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class ADDatributecreatedID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedID",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedID",
                table: "users");
        }
    }
}
