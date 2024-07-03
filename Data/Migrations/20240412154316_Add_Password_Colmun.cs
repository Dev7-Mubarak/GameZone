using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Password_Colmun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Passsword",
                table: "RestOwners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passsword",
                table: "RestOwners");
        }
    }
}
