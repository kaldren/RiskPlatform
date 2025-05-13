using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskPlatform.Modules.Bots.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BotInputFields_Bots_BotId",
                schema: "BotsModule",
                table: "BotInputFields");

            migrationBuilder.DropForeignKey(
                name: "FK_BotInputFiles_Bots_BotId",
                schema: "BotsModule",
                table: "BotInputFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_BotOutputFiles_Bots_BotId",
                schema: "BotsModule",
                table: "BotOutputFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BotOutputFiles",
                schema: "BotsModule",
                table: "BotOutputFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BotInputFiles",
                schema: "BotsModule",
                table: "BotInputFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BotInputFields",
                schema: "BotsModule",
                table: "BotInputFields");

            migrationBuilder.RenameTable(
                name: "BotOutputFiles",
                schema: "BotsModule",
                newName: "OutputFiles",
                newSchema: "BotsModule");

            migrationBuilder.RenameTable(
                name: "BotInputFiles",
                schema: "BotsModule",
                newName: "InputFiles",
                newSchema: "BotsModule");

            migrationBuilder.RenameTable(
                name: "BotInputFields",
                schema: "BotsModule",
                newName: "InputFields",
                newSchema: "BotsModule");

            migrationBuilder.RenameIndex(
                name: "IX_BotOutputFiles_BotId",
                schema: "BotsModule",
                table: "OutputFiles",
                newName: "IX_OutputFiles_BotId");

            migrationBuilder.RenameIndex(
                name: "IX_BotInputFiles_BotId",
                schema: "BotsModule",
                table: "InputFiles",
                newName: "IX_InputFiles_BotId");

            migrationBuilder.RenameIndex(
                name: "IX_BotInputFields_BotId",
                schema: "BotsModule",
                table: "InputFields",
                newName: "IX_InputFields_BotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutputFiles",
                schema: "BotsModule",
                table: "OutputFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InputFiles",
                schema: "BotsModule",
                table: "InputFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InputFields",
                schema: "BotsModule",
                table: "InputFields",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputFields_Bots_BotId",
                schema: "BotsModule",
                table: "InputFields",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputFiles_Bots_BotId",
                schema: "BotsModule",
                table: "InputFiles",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputFiles_Bots_BotId",
                schema: "BotsModule",
                table: "OutputFiles",
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
                name: "FK_InputFields_Bots_BotId",
                schema: "BotsModule",
                table: "InputFields");

            migrationBuilder.DropForeignKey(
                name: "FK_InputFiles_Bots_BotId",
                schema: "BotsModule",
                table: "InputFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputFiles_Bots_BotId",
                schema: "BotsModule",
                table: "OutputFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutputFiles",
                schema: "BotsModule",
                table: "OutputFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InputFiles",
                schema: "BotsModule",
                table: "InputFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InputFields",
                schema: "BotsModule",
                table: "InputFields");

            migrationBuilder.RenameTable(
                name: "OutputFiles",
                schema: "BotsModule",
                newName: "BotOutputFiles",
                newSchema: "BotsModule");

            migrationBuilder.RenameTable(
                name: "InputFiles",
                schema: "BotsModule",
                newName: "BotInputFiles",
                newSchema: "BotsModule");

            migrationBuilder.RenameTable(
                name: "InputFields",
                schema: "BotsModule",
                newName: "BotInputFields",
                newSchema: "BotsModule");

            migrationBuilder.RenameIndex(
                name: "IX_OutputFiles_BotId",
                schema: "BotsModule",
                table: "BotOutputFiles",
                newName: "IX_BotOutputFiles_BotId");

            migrationBuilder.RenameIndex(
                name: "IX_InputFiles_BotId",
                schema: "BotsModule",
                table: "BotInputFiles",
                newName: "IX_BotInputFiles_BotId");

            migrationBuilder.RenameIndex(
                name: "IX_InputFields_BotId",
                schema: "BotsModule",
                table: "BotInputFields",
                newName: "IX_BotInputFields_BotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BotOutputFiles",
                schema: "BotsModule",
                table: "BotOutputFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BotInputFiles",
                schema: "BotsModule",
                table: "BotInputFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BotInputFields",
                schema: "BotsModule",
                table: "BotInputFields",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BotInputFields_Bots_BotId",
                schema: "BotsModule",
                table: "BotInputFields",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BotInputFiles_Bots_BotId",
                schema: "BotsModule",
                table: "BotInputFiles",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BotOutputFiles_Bots_BotId",
                schema: "BotsModule",
                table: "BotOutputFiles",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
