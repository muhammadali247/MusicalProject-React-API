using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class UpdatedSocial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "SocialMediaLinks",
                newName: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaLinks_ArtistId",
                table: "SocialMediaLinks",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaLinks_Artists_ArtistId",
                table: "SocialMediaLinks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaLinks_Artists_ArtistId",
                table: "SocialMediaLinks");

            migrationBuilder.DropIndex(
                name: "IX_SocialMediaLinks_ArtistId",
                table: "SocialMediaLinks");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "SocialMediaLinks",
                newName: "EntityId");
        }
    }
}
