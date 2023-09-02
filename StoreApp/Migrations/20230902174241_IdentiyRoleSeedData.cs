using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentiyRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "049726ee-abba-4f44-ad73-bd5fc44fa5bf", "8bb4f894-fbb0-4df3-aff8-1efc0075de9f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b42c1e3e-46eb-4bb0-b996-50403b4468db", "61097da4-e93e-4025-9c05-9e92ec1f74e9", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa5cbcf2-304c-4479-8e31-32930206eb29", "2ca7e2d3-68a2-4f7c-bd10-108cceff0123", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "049726ee-abba-4f44-ad73-bd5fc44fa5bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42c1e3e-46eb-4bb0-b996-50403b4468db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa5cbcf2-304c-4479-8e31-32930206eb29");
        }
    }
}
