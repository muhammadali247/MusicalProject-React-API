using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class correctsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImage_Albums_AlbumId",
                table: "AlbumImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AlbumImage_MainCoverAlbumImageId",
                table: "Albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumImage",
                table: "AlbumImage");

            migrationBuilder.RenameTable(
                name: "AlbumImage",
                newName: "AlbumImages");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumImage_AlbumId",
                table: "AlbumImages",
                newName: "IX_AlbumImages_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumImages",
                table: "AlbumImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImages_Albums_AlbumId",
                table: "AlbumImages",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AlbumImages_MainCoverAlbumImageId",
                table: "Albums",
                column: "MainCoverAlbumImageId",
                principalTable: "AlbumImages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImages_Albums_AlbumId",
                table: "AlbumImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AlbumImages_MainCoverAlbumImageId",
                table: "Albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumImages",
                table: "AlbumImages");

            migrationBuilder.RenameTable(
                name: "AlbumImages",
                newName: "AlbumImage");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumImages_AlbumId",
                table: "AlbumImage",
                newName: "IX_AlbumImage_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumImage",
                table: "AlbumImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImage_Albums_AlbumId",
                table: "AlbumImage",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AlbumImage_MainCoverAlbumImageId",
                table: "Albums",
                column: "MainCoverAlbumImageId",
                principalTable: "AlbumImage",
                principalColumn: "Id");
        }
    }
}
