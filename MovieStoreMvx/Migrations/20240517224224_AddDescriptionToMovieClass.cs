using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStoreMvx.Migrations
{
    public partial class AddDescriptionToMovieClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movie");
        }
    }
}
