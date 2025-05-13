using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskPlatform.Modules.Bots.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BotScripts_Bots_BotId",
                schema: "BotsModule",
                table: "BotScripts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BotScripts",
                schema: "BotsModule",
                table: "BotScripts");

            migrationBuilder.RenameTable(
                name: "BotScripts",
                schema: "BotsModule",
                newName: "Scripts",
                newSchema: "BotsModule");

            migrationBuilder.RenameIndex(
                name: "IX_BotScripts_BotId",
                schema: "BotsModule",
                table: "Scripts",
                newName: "IX_Scripts_BotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scripts",
                schema: "BotsModule",
                table: "Scripts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scripts_Bots_BotId",
                schema: "BotsModule",
                table: "Scripts",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scripts_Bots_BotId",
                schema: "BotsModule",
                table: "Scripts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scripts",
                schema: "BotsModule",
                table: "Scripts");

            migrationBuilder.RenameTable(
                name: "Scripts",
                schema: "BotsModule",
                newName: "BotScripts",
                newSchema: "BotsModule");

            migrationBuilder.RenameIndex(
                name: "IX_Scripts_BotId",
                schema: "BotsModule",
                table: "BotScripts",
                newName: "IX_BotScripts_BotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BotScripts",
                schema: "BotsModule",
                table: "BotScripts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BotScripts_Bots_BotId",
                schema: "BotsModule",
                table: "BotScripts",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
