using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TESTPROJE_1_MVC.Migrations
{
    public partial class tableChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GetWords",
                table: "GetWords");

            migrationBuilder.RenameTable(
                name: "GetWords",
                newName: "Kelime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kelime",
                table: "Kelime",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Kelime",
                table: "Kelime");

            migrationBuilder.RenameTable(
                name: "Kelime",
                newName: "GetWords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetWords",
                table: "GetWords",
                column: "Id");
        }
    }
}
