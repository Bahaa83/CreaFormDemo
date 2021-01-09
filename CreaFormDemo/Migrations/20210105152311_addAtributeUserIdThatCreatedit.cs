using Microsoft.EntityFrameworkCore.Migrations;

namespace CreaFormDemo.Migrations
{
    public partial class addAtributeUserIdThatCreatedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedID",
                table: "users",
                newName: "UserIdThatCreatedit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserIdThatCreatedit",
                table: "users",
                newName: "CreatedID");
        }
    }
}
