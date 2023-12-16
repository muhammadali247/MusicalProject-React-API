using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class correctedExpiryDateColumnInAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OTPExpiration",
                table: "AspNetUsers",
                newName: "OTPExpiryDate");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OTPExpiryDate",
                table: "AspNetUsers",
                newName: "OTPExpiration");

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
    }
}
