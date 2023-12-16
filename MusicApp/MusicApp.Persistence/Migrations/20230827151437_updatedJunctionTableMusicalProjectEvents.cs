using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class updatedJunctionTableMusicalProjectEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicalProjectEvent_Events_EventId",
                table: "MusicalProjectEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicalProjectEvent_MusicalProjects_MusicalProjectId",
                table: "MusicalProjectEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicalProjectEvent",
                table: "MusicalProjectEvent");

            migrationBuilder.RenameTable(
                name: "MusicalProjectEvent",
                newName: "MusicalProjectEvents");

            migrationBuilder.RenameIndex(
                name: "IX_MusicalProjectEvent_MusicalProjectId",
                table: "MusicalProjectEvents",
                newName: "IX_MusicalProjectEvents_MusicalProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicalProjectEvent_EventId",
                table: "MusicalProjectEvents",
                newName: "IX_MusicalProjectEvents_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicalProjectEvents",
                table: "MusicalProjectEvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicalProjectEvents_Events_EventId",
                table: "MusicalProjectEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicalProjectEvents_MusicalProjects_MusicalProjectId",
                table: "MusicalProjectEvents",
                column: "MusicalProjectId",
                principalTable: "MusicalProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicalProjectEvents_Events_EventId",
                table: "MusicalProjectEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicalProjectEvents_MusicalProjects_MusicalProjectId",
                table: "MusicalProjectEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicalProjectEvents",
                table: "MusicalProjectEvents");

            migrationBuilder.RenameTable(
                name: "MusicalProjectEvents",
                newName: "MusicalProjectEvent");

            migrationBuilder.RenameIndex(
                name: "IX_MusicalProjectEvents_MusicalProjectId",
                table: "MusicalProjectEvent",
                newName: "IX_MusicalProjectEvent_MusicalProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicalProjectEvents_EventId",
                table: "MusicalProjectEvent",
                newName: "IX_MusicalProjectEvent_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicalProjectEvent",
                table: "MusicalProjectEvent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicalProjectEvent_Events_EventId",
                table: "MusicalProjectEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicalProjectEvent_MusicalProjects_MusicalProjectId",
                table: "MusicalProjectEvent",
                column: "MusicalProjectId",
                principalTable: "MusicalProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
