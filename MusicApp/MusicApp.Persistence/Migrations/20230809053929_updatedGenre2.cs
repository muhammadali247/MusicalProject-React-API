using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class updatedGenre2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "Genres");
        }
    }
}
