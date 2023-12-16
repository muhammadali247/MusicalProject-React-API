using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class updatedTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaLinks_MusicalProjects_MusicalProjectId",
                table: "SocialMediaLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaLinks_UserProfiles_UserProfileId",
                table: "SocialMediaLinks");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserProfileId",
                table: "SocialMediaLinks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MusicalProjectId",
                table: "SocialMediaLinks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "SocialMediaLinks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntityType",
                table: "SocialMediaLinks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MusicalProjects",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaLinks_MusicalProjects_MusicalProjectId",
                table: "SocialMediaLinks",
                column: "MusicalProjectId",
                principalTable: "MusicalProjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaLinks_UserProfiles_UserProfileId",
                table: "SocialMediaLinks",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaLinks_MusicalProjects_MusicalProjectId",
                table: "SocialMediaLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaLinks_UserProfiles_UserProfileId",
                table: "SocialMediaLinks");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "SocialMediaLinks");

            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "SocialMediaLinks");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserProfileId",
                table: "SocialMediaLinks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MusicalProjectId",
                table: "SocialMediaLinks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MusicalProjects",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaLinks_MusicalProjects_MusicalProjectId",
                table: "SocialMediaLinks",
                column: "MusicalProjectId",
                principalTable: "MusicalProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaLinks_UserProfiles_UserProfileId",
                table: "SocialMediaLinks",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
