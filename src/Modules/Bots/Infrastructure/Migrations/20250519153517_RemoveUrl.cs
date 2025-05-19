using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskPlatform.Modules.Bots.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                schema: "BotsModule",
                table: "Outputs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "BotsModule",
                table: "Outputs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
