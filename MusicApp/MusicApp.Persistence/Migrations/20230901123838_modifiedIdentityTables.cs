using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApp.Persistence.Migrations
{
    public partial class modifiedIdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "be6f0af5-4bfa-4717-95d1-04a6e3092e3d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "cdf0f5b8-5892-444b-88c8-20558bdfe5a3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63ded149-0cc6-43cd-bfc4-635dc3de2a9b", "4eb44926-df29-472e-afc6-1e26b36cf422", "Member", "MEMBER" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63ded149-0cc6-43cd-bfc4-635dc3de2a9b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fec4cb-7540-48c5-b08a-aa6642957f1c",
                column: "ConcurrencyStamp",
                value: "98e4d050-0170-4b02-a523-130770e6c4b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f177b9b-2126-42b3-a9ea-113e526a763a",
                column: "ConcurrencyStamp",
                value: "a9e7c74f-9bc3-42e7-8a9e-84cf2fa8d365");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04da0a6b-6fd2-4779-843a-3e7c5892da1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75505ea5-7008-4b95-83a5-57b335dfbc1b", "AQAAAAEAACcQAAAAEEPCxhlc46CGdQJ9uGvwYVlCVpRVxgtFSdb/Yc70oMAKhlvyTZAPSfpmxDjAH0Phbw==", "cf123430-47ae-48e8-9106-8e2e5782e2d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a09c2ad5-7446-4435-91c9-cd038b96b3ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90e9ea94-4e3c-4bb5-934d-f758c2a622cf", "AQAAAAEAACcQAAAAEH/Km0kSKIFJkK/hjsoyfwStxPNhPEX0yHOrxs8QlIaxjlCPnXNt10IAMOKdz+WWBQ==", "09d766dd-033e-47f2-9d25-20bb40fbab37" });
        }
    }
}
