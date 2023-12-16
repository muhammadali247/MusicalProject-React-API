using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class addedRefreshTokenTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "8882cbd0-f260-4621-96cb-7d3470648139");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "566bb3d8-d49b-4e38-ad85-a0f39515f76d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "a3e75eec-30fc-48b6-a279-a96b6ba696c2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1692bdc9-a016-43c3-8d84-880ced648f87", "AQAAAAEAACcQAAAAEH35Z369TmqaO9B+cJfc037yAvDN+vIZkTEWTQ8fI9R65CFmo/4HS6dNMBMaT2qkdA==", "025e479f-43f3-41b3-a43f-cfc869d53a0a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "319e8634-47ef-40b3-9520-cc4a375577ec", "AQAAAAEAACcQAAAAEFGAkElJWgvRHxq2XSYv2HrcsInVDl6riDZq8SpiUItbChS2zg7RqsoQyQNyRgDKXw==", "e23b47b5-609f-4763-a775-23966008b558" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "d6f730ec-ec7b-43e3-bfe4-b691ed4e717a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "270cf933-b5b5-4a8f-9b65-4af64cf62446");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "ba0059d6-498a-46d7-bd4e-7632df909451");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ba2d83c-aced-4810-bd11-011c76eda90a", "AQAAAAEAACcQAAAAEAnKsh3GZyxlCUNRxyTFRbIAUtCpAONNNyqDMRx7r5GKOUAB5AyaKashMn6VcZDBQQ==", "c23f30c6-c5f9-4ab0-a835-3d071563bf0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "166f9b67-3398-4d3b-b9a6-3ba7b789e095", "AQAAAAEAACcQAAAAEHUiRCYgL3yP3kK5G4+MtlUxQFWJzMbHAQPoiW92Pc5IyIQmqyIu1FEAq4QSICJFmQ==", "070ee3fc-d6cb-4f45-902b-b883a3a9cd21" });
        }
    }
}
