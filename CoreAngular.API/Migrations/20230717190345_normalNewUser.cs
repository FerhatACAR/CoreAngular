using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAngular.API.Migrations
{
    /// <inheritdoc />
    public partial class normalNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "COREANGULAR");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "COREANGULAR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                schema: "COREANGULAR",
                newName: "Users");
        }
    }
}
