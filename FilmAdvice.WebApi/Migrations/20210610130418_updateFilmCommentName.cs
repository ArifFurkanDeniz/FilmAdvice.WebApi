using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmAdvice.WebApi.Migrations
{
    public partial class updateFilmCommentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmComments_Films_FormId",
                table: "FilmComments");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "FilmComments",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmComments_FormId",
                table: "FilmComments",
                newName: "IX_FilmComments_FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmComments_Films_FilmId",
                table: "FilmComments",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmComments_Films_FilmId",
                table: "FilmComments");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "FilmComments",
                newName: "FormId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmComments_FilmId",
                table: "FilmComments",
                newName: "IX_FilmComments_FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmComments_Films_FormId",
                table: "FilmComments",
                column: "FormId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
