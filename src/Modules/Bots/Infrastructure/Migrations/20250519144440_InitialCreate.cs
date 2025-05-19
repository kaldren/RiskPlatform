using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskPlatform.Modules.Bots.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "BotsModule",
                table: "Parameters",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "BotsModule",
                table: "Bots",
                newName: "ModifiedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                schema: "BotsModule",
                table: "Parameters",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                schema: "BotsModule",
                table: "Bots",
                newName: "UpdatedAt");
        }
    }
}
