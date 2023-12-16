using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class updatedRefreshTokensTable4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRevoked",
                table: "RefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRevoked",
                table: "RefreshTokens");

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
        }
    }
}
