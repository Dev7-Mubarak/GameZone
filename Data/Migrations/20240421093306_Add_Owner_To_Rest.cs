using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Owner_To_Rest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rests_RestId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RestId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProilePicture",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RestId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Rests",
                newName: "Addrees");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Rests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rests_OwnerId",
                table: "Rests",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Rests_Users_OwnerId",
                table: "Rests",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rests_Users_OwnerId",
                table: "Rests");

            migrationBuilder.DropIndex(
                name: "IX_Rests_OwnerId",
                table: "Rests");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Rests");

            migrationBuilder.RenameColumn(
                name: "Addrees",
                table: "Rests",
                newName: "Location");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProilePicture",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RestId",
                table: "Users",
                column: "RestId",
                unique: true,
                filter: "[RestId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rests_RestId",
                table: "Users",
                column: "RestId",
                principalTable: "Rests",
                principalColumn: "Id");
        }
    }
}
