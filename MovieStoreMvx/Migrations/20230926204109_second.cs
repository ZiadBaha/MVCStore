using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStoreMvx.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_movieGenre",
                table: "movieGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie",
                table: "movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genre",
                table: "genre");

            migrationBuilder.RenameTable(
                name: "movieGenre",
                newName: "MovieGenre");

            migrationBuilder.RenameTable(
                name: "movie",
                newName: "Movie");

            migrationBuilder.RenameTable(
                name: "genre",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "Tittle",
                table: "Movie",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ReleasYear",
                table: "Movie",
                newName: "ReleaseYear");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenre",
                table: "MovieGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "MovieGenre",
                newName: "movieGenre");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "movie");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "movie",
                newName: "Tittle");

            migrationBuilder.RenameColumn(
                name: "ReleaseYear",
                table: "movie",
                newName: "ReleasYear");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movieGenre",
                table: "movieGenre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie",
                table: "movie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genre",
                table: "genre",
                column: "Id");
        }
    }
}
