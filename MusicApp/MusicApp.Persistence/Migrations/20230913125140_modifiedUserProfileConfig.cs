using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class modifiedUserProfileConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "446f943d-13b8-428c-8575-2d79327efdef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "7f120884-eb98-4d56-8d75-86b479c2a523");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "36b95b32-5a4d-450e-87df-9960d98a4340");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31a4e634-c523-4613-9e21-2e075950c4a7", "AQAAAAEAACcQAAAAEHx/tDNX1N3sQzD/OYF9zJaqxL0zEs1WOw3gFcqzgpHB6XT7eFIiqf1Ur3qu5isNTQ==", "fbf14468-f7be-45dc-98ea-4f44eec1a4d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae503650-7dad-4d6f-ba7b-65fb605cb8c2", "AQAAAAEAACcQAAAAELSg8MLgm1A0HBH9v4Rm70ZXkxp6EYopkyIQ8UN48XnARFj4ho6IduWlEzf7uHAC8Q==", "63d29463-64d9-4a67-a126-108be31f9082" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
