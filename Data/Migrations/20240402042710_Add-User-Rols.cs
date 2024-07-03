using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameZone.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "446b318b-fa6f-4647-bc9c-75371febabca", "52dfacb6-28b6-4ba8-9af7-5726659e9710", "User", "user" },
                    { "b3011c03-84af-40fd-9bf4-4d28e0bc2de0", "68208f34-3695-459f-b2ff-eb9517d0ee28", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "446b318b-fa6f-4647-bc9c-75371febabca");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b3011c03-84af-40fd-9bf4-4d28e0bc2de0");
        }
    }
}
