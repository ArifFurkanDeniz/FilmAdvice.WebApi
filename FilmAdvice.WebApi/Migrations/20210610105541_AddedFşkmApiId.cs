using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmAdvice.WebApi.Migrations
{
    public partial class AddedFşkmApiId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmApiId",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmApiId",
                table: "Films");
        }
    }
}
