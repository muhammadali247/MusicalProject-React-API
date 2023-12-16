using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class udpatedAppUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OTPExpiration",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "e2d69579-9ce6-4bf7-8b76-7efda2514d14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "da0e4f5a-0ffd-465a-84a5-9bed8746d235");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "924636d6-f964-48be-9b7c-b4e918a0612f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0a16a7d-e676-409e-a47a-f4b4f81dfd41", "AQAAAAEAACcQAAAAELtSmK/0/WedoVA5/vNlhRO32QNvPJOs4n6Ee7nxF3C9Khvtw2U3gBLAhZ1vCcD+KQ==", "22cbb6e8-b508-45d6-83ec-dd1e9973772d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "775422db-cef6-48e8-8dad-30ea04794262", "AQAAAAEAACcQAAAAEGdJ0qMg9ghFkwNBvr9lfQPGVIrRTIOWgUAux9WA4Z/XRzvbZMqieytuQ12TVxUWdA==", "01ca5519-ff52-447e-a523-ac5244bb0a9f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTPExpiration",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "be6f0af5-4bfa-4717-95d1-04a6e3092e3d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "4eb44926-df29-472e-afc6-1e26b36cf422");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "cdf0f5b8-5892-444b-88c8-20558bdfe5a3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc32ec2a-b04b-47f5-a284-94522a522a48", "AQAAAAEAACcQAAAAEBjijCVhNR/9AbRI0RkitVl+hY9BAJL2FA0wi63mFEqhkKpxFzSgny4AEJJ7+3QM2w==", "afc9278b-9cdf-4710-b5f5-8d0e54bb8b56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae831721-1eae-4340-b301-030fb6c07a9a", "AQAAAAEAACcQAAAAEBDYyfj1caEBQubL/eosaFDXYGN1ojej8ed1dA5ycIW59b/cDdpbYnqemb7teizmeA==", "01b1df1d-0fa1-43f6-bb73-0bcd57cc6372" });
        }
    }
}
