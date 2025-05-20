using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskPlatform.Modules.Bots.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate51 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BotsModule");

            migrationBuilder.CreateTable(
                name: "Bots",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ScriptUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inputs",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inputs_Bots_BotId",
                        column: x => x.BotId,
                        principalSchema: "BotsModule",
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outputs",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outputs_Bots_BotId",
                        column: x => x.BotId,
                        principalSchema: "BotsModule",
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Runs",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Runs_Bots_BotId",
                        column: x => x.BotId,
                        principalSchema: "BotsModule",
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RunInputs",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RunId = table.Column<int>(type: "int", nullable: false),
                    BotInputId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunInputs_Inputs_BotInputId",
                        column: x => x.BotInputId,
                        principalSchema: "BotsModule",
                        principalTable: "Inputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RunInputs_Runs_RunId",
                        column: x => x.RunId,
                        principalSchema: "BotsModule",
                        principalTable: "Runs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RunOutputs",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RunId = table.Column<int>(type: "int", nullable: false),
                    BotOutputId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunOutputs_Outputs_BotOutputId",
                        column: x => x.BotOutputId,
                        principalSchema: "BotsModule",
                        principalTable: "Outputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RunOutputs_Runs_RunId",
                        column: x => x.RunId,
                        principalSchema: "BotsModule",
                        principalTable: "Runs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bots_Name",
                schema: "BotsModule",
                table: "Bots",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_BotId",
                schema: "BotsModule",
                table: "Inputs",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_BotId",
                schema: "BotsModule",
                table: "Outputs",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_RunInputs_BotInputId",
                schema: "BotsModule",
                table: "RunInputs",
                column: "BotInputId");

            migrationBuilder.CreateIndex(
                name: "IX_RunInputs_RunId",
                schema: "BotsModule",
                table: "RunInputs",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_RunOutputs_BotOutputId",
                schema: "BotsModule",
                table: "RunOutputs",
                column: "BotOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_RunOutputs_RunId",
                schema: "BotsModule",
                table: "RunOutputs",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_Runs_BotId",
                schema: "BotsModule",
                table: "Runs",
                column: "BotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunInputs",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "RunOutputs",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "Inputs",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "Outputs",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "Runs",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "Bots",
                schema: "BotsModule");
        }
    }
}
