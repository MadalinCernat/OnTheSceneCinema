using Microsoft.EntityFrameworkCore.Migrations;

namespace OnTheSceneWebApp.Migrations
{
    public partial class Actors_Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Actors",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Actors",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
