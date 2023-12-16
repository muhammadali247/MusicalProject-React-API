using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class addedConfigurationsForUserProfilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaLinks_UserProfiles_UserProfileId",
                table: "SocialMediaLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteArtist_Artists_ArtistId",
                table: "UserFavoriteArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteArtist_UserProfiles_UserProfileId",
                table: "UserFavoriteArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteGenre_Genres_GenreId",
                table: "UserFavoriteGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteGenre_UserProfiles_UserProfileId",
                table: "UserFavoriteGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMusicalProject_MusicalProjects_MusicalProjectId",
                table: "UserFavoriteMusicalProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMusicalProject_UserProfiles_UserProfileId",
                table: "UserFavoriteMusicalProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteMusicalProject",
                table: "UserFavoriteMusicalProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteGenre",
                table: "UserFavoriteGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteArtist",
                table: "UserFavoriteArtist");

            migrationBuilder.RenameTable(
                name: "UserFavoriteMusicalProject",
                newName: "UserFavoriteMusicalProjects");

            migrationBuilder.RenameTable(
                name: "UserFavoriteGenre",
                newName: "UserFavoriteGenres");

            migrationBuilder.RenameTable(
                name: "UserFavoriteArtist",
                newName: "UserFavoriteArtists");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteMusicalProject_UserProfileId",
                table: "UserFavoriteMusicalProjects",
                newName: "IX_UserFavoriteMusicalProjects_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteMusicalProject_MusicalProjectId",
                table: "UserFavoriteMusicalProjects",
                newName: "IX_UserFavoriteMusicalProjects_MusicalProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteGenre_UserProfileId",
                table: "UserFavoriteGenres",
                newName: "IX_UserFavoriteGenres_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteGenre_GenreId",
                table: "UserFavoriteGenres",
                newName: "IX_UserFavoriteGenres_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteArtist_UserProfileId",
                table: "UserFavoriteArtists",
                newName: "IX_UserFavoriteArtists_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteArtist_ArtistId",
                table: "UserFavoriteArtists",
                newName: "IX_UserFavoriteArtists_ArtistId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserFavoriteMusicalProjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserFavoriteGenres",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserFavoriteArtists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteMusicalProjects",
                table: "UserFavoriteMusicalProjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteGenres",
                table: "UserFavoriteGenres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteArtists",
                table: "UserFavoriteArtists",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "ea19c035-eabf-48e8-bd8f-36da1406f3d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "9259771f-50a8-473a-9f85-43c016869a89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "5aa84201-eff9-4f51-8cff-06846a4c9e0f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d13f8415-6ddf-455f-b57d-5e5ca0d04de2", "AQAAAAEAACcQAAAAEHHHkX59NXkS9f/fGLfb7I1bwp4ez0ByaVbt0aho4lf6ydNO3pPItQUbKNYmntF5AA==", "4c3dec39-68aa-4acf-aa04-24e7a3b82205" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a7e1573-ab70-4456-80df-808bec23e486", "AQAAAAEAACcQAAAAENth1Sw8f2eFkXiwf5kzBy6j2s+/RDa3JRquoYzHDxtXazZ35CFbjXEnAsi+wYr9CA==", "e498a76d-9510-458f-809a-c2cb9ae7c16e" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserProfileId",
                table: "AspNetUsers",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserProfiles_UserProfileId",
                table: "AspNetUsers",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaLinks_UserProfiles_UserProfileId",
                table: "SocialMediaLinks",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteArtists_Artists_ArtistId",
                table: "UserFavoriteArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteArtists_UserProfiles_UserProfileId",
                table: "UserFavoriteArtists",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteGenres_Genres_GenreId",
                table: "UserFavoriteGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteGenres_UserProfiles_UserProfileId",
                table: "UserFavoriteGenres",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMusicalProjects_MusicalProjects_MusicalProjectId",
                table: "UserFavoriteMusicalProjects",
                column: "MusicalProjectId",
                principalTable: "MusicalProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMusicalProjects_UserProfiles_UserProfileId",
                table: "UserFavoriteMusicalProjects",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserProfiles_UserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaLinks_UserProfiles_UserProfileId",
                table: "SocialMediaLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteArtists_Artists_ArtistId",
                table: "UserFavoriteArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteArtists_UserProfiles_UserProfileId",
                table: "UserFavoriteArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteGenres_Genres_GenreId",
                table: "UserFavoriteGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteGenres_UserProfiles_UserProfileId",
                table: "UserFavoriteGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMusicalProjects_MusicalProjects_MusicalProjectId",
                table: "UserFavoriteMusicalProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteMusicalProjects_UserProfiles_UserProfileId",
                table: "UserFavoriteMusicalProjects");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteMusicalProjects",
                table: "UserFavoriteMusicalProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteGenres",
                table: "UserFavoriteGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteArtists",
                table: "UserFavoriteArtists");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserFavoriteMusicalProjects",
                newName: "UserFavoriteMusicalProject");

            migrationBuilder.RenameTable(
                name: "UserFavoriteGenres",
                newName: "UserFavoriteGenre");

            migrationBuilder.RenameTable(
                name: "UserFavoriteArtists",
                newName: "UserFavoriteArtist");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteMusicalProjects_UserProfileId",
                table: "UserFavoriteMusicalProject",
                newName: "IX_UserFavoriteMusicalProject_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteMusicalProjects_MusicalProjectId",
                table: "UserFavoriteMusicalProject",
                newName: "IX_UserFavoriteMusicalProject_MusicalProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteGenres_UserProfileId",
                table: "UserFavoriteGenre",
                newName: "IX_UserFavoriteGenre_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteGenres_GenreId",
                table: "UserFavoriteGenre",
                newName: "IX_UserFavoriteGenre_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteArtists_UserProfileId",
                table: "UserFavoriteArtist",
                newName: "IX_UserFavoriteArtist_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteArtists_ArtistId",
                table: "UserFavoriteArtist",
                newName: "IX_UserFavoriteArtist_ArtistId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserFavoriteMusicalProject",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserFavoriteGenre",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserFavoriteArtist",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteMusicalProject",
                table: "UserFavoriteMusicalProject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteGenre",
                table: "UserFavoriteGenre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteArtist",
                table: "UserFavoriteArtist",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "c231816b-b353-46cf-90e7-3de05d621fa6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "899ca865-0ac5-479f-8c0e-9dbb5eb002ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "5810572b-3be3-4040-be50-d3c8897174c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c61f224c-7abc-43d7-be25-23a9d687a732", "AQAAAAEAACcQAAAAEL8rt2kuhDUT5f/WmNPiFwZbzazFuYygDSQEGKP7CZY+Sbom0iLkiKVbvsVVncSu0w==", "9717024a-417b-48ba-bc31-4a7b11ed4f65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03b4e0cb-cd71-45e1-8289-cf1a22890392", "AQAAAAEAACcQAAAAEBAe5P4ryC/Bl9rK/Rg7YkKoCrGPtpKKwQk0ZkXHqST+XvColScrHmLWvMAq/ll5MQ==", "f9b2df85-7ffc-4cd2-b8be-4fbb3740e192" });

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaLinks_UserProfiles_UserProfileId",
                table: "SocialMediaLinks",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteArtist_Artists_ArtistId",
                table: "UserFavoriteArtist",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteArtist_UserProfiles_UserProfileId",
                table: "UserFavoriteArtist",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteGenre_Genres_GenreId",
                table: "UserFavoriteGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteGenre_UserProfiles_UserProfileId",
                table: "UserFavoriteGenre",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMusicalProject_MusicalProjects_MusicalProjectId",
                table: "UserFavoriteMusicalProject",
                column: "MusicalProjectId",
                principalTable: "MusicalProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteMusicalProject_UserProfiles_UserProfileId",
                table: "UserFavoriteMusicalProject",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
