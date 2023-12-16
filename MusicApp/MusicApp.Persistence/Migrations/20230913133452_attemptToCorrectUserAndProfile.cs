using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class attemptToCorrectUserAndProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "37e00d44-9d81-48a5-986e-5091574f49cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "3eafe110-13e1-4a7f-a30b-055098b3c0de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "e4900612-5f29-46b3-b635-b12475bf7791");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e93345f-9043-498d-80c2-dab57d293f43", "AQAAAAEAACcQAAAAEOoMils89OR05tHIJL+QzM7BxAcoNduvKCkIr8v9fZaVLGji0zodkTJJYIjF4D+V7A==", "6102bf24-c505-481a-a27a-45791c6af464" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af151797-2018-46ac-b302-75b14ab6c72b", "AQAAAAEAACcQAAAAELkHq7Qb9pFepAYFRogDw+cd1il2YVUGEe+T6iO0w8FtzYXxLZmET8XyDVROIHQzLg==", "9800cff0-23f5-489d-a69c-b2c4abf83e6b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "f434b7bd-0075-44ec-87df-0c9f05034c0f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b",
                column: "ConcurrencyStamp",
                value: "45038eb4-2694-4fe7-b1bf-d198700b61e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "475eb1d1-8d03-4d43-a651-5bddd6df5e42");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a80b3fa5-7dab-4316-aac6-f84ac1e3775e", "AQAAAAEAACcQAAAAEN2XWXfteaRjNX/s05lH8OsjxN/uVAjWsZpoSDTWscwteYGdmso8fB2ED3b1bDIf/A==", "8d175fdc-1559-4077-84e6-e6b3ed372980" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6a46209-faa6-4295-a2ea-9a48bc98559e", "AQAAAAEAACcQAAAAEB+iWBCqHSt3xK48mqIQt89qj4wqMgYa+MaPdZo2ze2fEfdHbXmE4H9AQW3O70NwIA==", "a61701b2-8407-4102-8ffc-607adb0f59af" });
        }
    }
}
