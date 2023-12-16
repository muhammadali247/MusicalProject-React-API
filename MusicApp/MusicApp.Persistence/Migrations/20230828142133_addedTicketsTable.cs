using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class addedTicketsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Events_EventId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Events_EventId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Events_EventId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_OrderItem_OrderItemId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Songs_EventId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Albums_EventId",
                table: "Albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_OrderItemId",
                table: "Tickets",
                newName: "IX_Tickets_OrderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_EventId",
                table: "Tickets",
                newName: "IX_Tickets_EventId");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderItemId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_OrderItem_OrderItemId",
                table: "Tickets",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_OrderItem_OrderItemId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_OrderItemId",
                table: "Ticket",
                newName: "IX_Ticket_OrderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EventId",
                table: "Ticket",
                newName: "IX_Ticket_EventId");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Albums",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderItemId",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_EventId",
                table: "Songs",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_EventId",
                table: "Albums",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Events_EventId",
                table: "Albums",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Events_EventId",
                table: "Songs",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Events_EventId",
                table: "Ticket",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_OrderItem_OrderItemId",
                table: "Ticket",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
