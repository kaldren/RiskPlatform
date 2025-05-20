using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskPlatform.Modules.Bots.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inputs_Bots_BotId",
                schema: "BotsModule",
                table: "Inputs");

            migrationBuilder.DropForeignKey(
                name: "FK_Outputs_Bots_BotId",
                schema: "BotsModule",
                table: "Outputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RunInputs_Inputs_BotInputId",
                schema: "BotsModule",
                table: "RunInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RunOutputs_Outputs_BotOutputId",
                schema: "BotsModule",
                table: "RunOutputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Outputs",
                schema: "BotsModule",
                table: "Outputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inputs",
                schema: "BotsModule",
                table: "Inputs");

            migrationBuilder.RenameTable(
                name: "Outputs",
                schema: "BotsModule",
                newName: "BotOutputs",
                newSchema: "BotsModule");

            migrationBuilder.RenameTable(
                name: "Inputs",
                schema: "BotsModule",
                newName: "BotInputs",
                newSchema: "BotsModule");

            migrationBuilder.RenameIndex(
                name: "IX_Outputs_BotId",
                schema: "BotsModule",
                table: "BotOutputs",
                newName: "IX_BotOutputs_BotId");

            migrationBuilder.RenameIndex(
                name: "IX_Inputs_BotId",
                schema: "BotsModule",
                table: "BotInputs",
                newName: "IX_BotInputs_BotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BotOutputs",
                schema: "BotsModule",
                table: "BotOutputs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BotInputs",
                schema: "BotsModule",
                table: "BotInputs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BotInputs_Bots_BotId",
                schema: "BotsModule",
                table: "BotInputs",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BotOutputs_Bots_BotId",
                schema: "BotsModule",
                table: "BotOutputs",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RunInputs_BotInputs_BotInputId",
                schema: "BotsModule",
                table: "RunInputs",
                column: "BotInputId",
                principalSchema: "BotsModule",
                principalTable: "BotInputs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RunOutputs_BotOutputs_BotOutputId",
                schema: "BotsModule",
                table: "RunOutputs",
                column: "BotOutputId",
                principalSchema: "BotsModule",
                principalTable: "BotOutputs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BotInputs_Bots_BotId",
                schema: "BotsModule",
                table: "BotInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_BotOutputs_Bots_BotId",
                schema: "BotsModule",
                table: "BotOutputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RunInputs_BotInputs_BotInputId",
                schema: "BotsModule",
                table: "RunInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_RunOutputs_BotOutputs_BotOutputId",
                schema: "BotsModule",
                table: "RunOutputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BotOutputs",
                schema: "BotsModule",
                table: "BotOutputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BotInputs",
                schema: "BotsModule",
                table: "BotInputs");

            migrationBuilder.RenameTable(
                name: "BotOutputs",
                schema: "BotsModule",
                newName: "Outputs",
                newSchema: "BotsModule");

            migrationBuilder.RenameTable(
                name: "BotInputs",
                schema: "BotsModule",
                newName: "Inputs",
                newSchema: "BotsModule");

            migrationBuilder.RenameIndex(
                name: "IX_BotOutputs_BotId",
                schema: "BotsModule",
                table: "Outputs",
                newName: "IX_Outputs_BotId");

            migrationBuilder.RenameIndex(
                name: "IX_BotInputs_BotId",
                schema: "BotsModule",
                table: "Inputs",
                newName: "IX_Inputs_BotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Outputs",
                schema: "BotsModule",
                table: "Outputs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inputs",
                schema: "BotsModule",
                table: "Inputs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inputs_Bots_BotId",
                schema: "BotsModule",
                table: "Inputs",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Outputs_Bots_BotId",
                schema: "BotsModule",
                table: "Outputs",
                column: "BotId",
                principalSchema: "BotsModule",
                principalTable: "Bots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RunInputs_Inputs_BotInputId",
                schema: "BotsModule",
                table: "RunInputs",
                column: "BotInputId",
                principalSchema: "BotsModule",
                principalTable: "Inputs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RunOutputs_Outputs_BotOutputId",
                schema: "BotsModule",
                table: "RunOutputs",
                column: "BotOutputId",
                principalSchema: "BotsModule",
                principalTable: "Outputs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
