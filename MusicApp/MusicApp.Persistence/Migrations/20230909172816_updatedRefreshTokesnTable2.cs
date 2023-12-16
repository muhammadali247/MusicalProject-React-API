using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class updatedRefreshTokesnTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "1f7179de-f843-400e-9be2-b60d19b7f015");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "bfd287b0-aa39-4ede-81ca-322816f3729c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "292bf596-33c8-453e-932a-de7ed6fab45f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36f98ef6-93b2-4734-a924-5f4cd4213b34", "AQAAAAEAACcQAAAAEOOBzrqObL5I6yrXOOH6pEmhlp+moo8lGcQaJLaglZ/c1QfEDDl8aOs2zyYpNaF0LQ==", "f4aa453d-e7a0-43a8-85bd-0309a753686c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a165956f-2084-4486-9681-8e11be3f77a0", "AQAAAAEAACcQAAAAEICGh7FfdTP4juctJTLyI+8ezVZjkp6ovtCiMKmEJ+E7eQgy8JaWlpasrKN2Qw+Vhg==", "67b5c403-a007-449c-8922-09f699c38f82" });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RefreshTokens",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "f7339400-f0c9-4757-bc98-24fa38f682a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "57c37bad-0402-4b0a-b7df-e84bf90170da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "fc3bd354-c53f-412e-9e61-571487dd606c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9485ea08-273d-481a-abe5-4c28d50815c3", "AQAAAAEAACcQAAAAEKSwAO679nLwh4GuF5zjezFTOdcx1CtPfwYiNcfv9gyzTLDnsdh2rYwY6OUxLWb7Vw==", "4795c049-85da-4b0d-acbf-5eb7025206e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2796bd5e-a6bf-41d4-90bb-3a4bff33e0c7", "AQAAAAEAACcQAAAAEPDWBs1U1zFRV5fFMV1incsV4cvpnTUVB8aFxtN/WPsOT/PpFeUYS4L+YGCCMMPTwQ==", "f2e8243d-602a-4dd4-9c34-df57a50f5118" });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
