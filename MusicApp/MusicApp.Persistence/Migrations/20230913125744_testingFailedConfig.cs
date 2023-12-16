using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class testingFailedConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "562d9950-287f-4b8c-8cf9-8ca5cafba7ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "72979be6-5b8e-4236-b1ff-1e9bae283531");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "42f1e947-96b9-470f-add6-339dcc21e41e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ab3f1c2-03fe-4293-8510-279fdd009f42", "AQAAAAEAACcQAAAAEJpWEsovvLJuMbFhXWqzP1jCpU1z2/HsE/ixe2oCzfsJkyT8mYQ05HsFZVJuwxujIQ==", "db6eac9b-2555-476c-bf25-d29e7f6b9219" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b51324df-9375-4a27-aeab-aff455d0ae06", "AQAAAAEAACcQAAAAEAUzl8JNoapd7Vj3bO9m7JEkggAnlqYKfc9jgaq0Pv46SpYjjWnh5nOYWNdbnK8Vug==", "e3d9bdf7-f5d6-45ca-806a-961f431ace01" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
