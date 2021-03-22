using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalogo_Blazor.Server.Migrations
{
    public partial class CriaRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e1d9cba-fb65-4c7b-af23-a02d3578b932", "e0fbd88f-99ae-41e6-81d3-12064af30db1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d3bbc71-ebf8-4cca-b202-c5ce51cccdf0", "ee40cd62-d2ee-4b71-a149-7fd7d6e5a885", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3bbc71-ebf8-4cca-b202-c5ce51cccdf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e1d9cba-fb65-4c7b-af23-a02d3578b932");
        }
    }
}
