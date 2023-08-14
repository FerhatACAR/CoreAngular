using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAngular.API.Migrations
{
    /// <inheritdoc />
    public partial class userpasswordAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                schema: "COREANGULAR",
                table: "Users",
                type: "RAW(2000)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                schema: "COREANGULAR",
                table: "Users",
                type: "RAW(2000)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "COREANGULAR",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "COREANGULAR",
                table: "Users");
        }
    }
}
