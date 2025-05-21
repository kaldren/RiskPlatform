using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskPlatform.Modules.Bots.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BotFiles",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotFiles_Bots_BotId",
                        column: x => x.BotId,
                        principalSchema: "BotsModule",
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BotParameters",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotParameters_Bots_BotId",
                        column: x => x.BotId,
                        principalSchema: "BotsModule",
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BotRuns",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotRuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotRuns_Bots_BotId",
                        column: x => x.BotId,
                        principalSchema: "BotsModule",
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BotRunFiles",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotRunId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotRunFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotRunFiles_BotRuns_BotRunId",
                        column: x => x.BotRunId,
                        principalSchema: "BotsModule",
                        principalTable: "BotRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BotRunParameters",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotRunId = table.Column<int>(type: "int", nullable: false),
                    BotParameterId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotRunParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotRunParameters_BotParameters_BotParameterId",
                        column: x => x.BotParameterId,
                        principalSchema: "BotsModule",
                        principalTable: "BotParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BotRunParameters_BotRuns_BotRunId",
                        column: x => x.BotRunId,
                        principalSchema: "BotsModule",
                        principalTable: "BotRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotFiles_BotId",
                schema: "BotsModule",
                table: "BotFiles",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_BotParameters_BotId",
                schema: "BotsModule",
                table: "BotParameters",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_BotRunFiles_BotRunId",
                schema: "BotsModule",
                table: "BotRunFiles",
                column: "BotRunId");

            migrationBuilder.CreateIndex(
                name: "IX_BotRunParameters_BotParameterId",
                schema: "BotsModule",
                table: "BotRunParameters",
                column: "BotParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_BotRunParameters_BotRunId",
                schema: "BotsModule",
                table: "BotRunParameters",
                column: "BotRunId");

            migrationBuilder.CreateIndex(
                name: "IX_BotRuns_BotId",
                schema: "BotsModule",
                table: "BotRuns",
                column: "BotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotFiles",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "BotRunFiles",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "BotRunParameters",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "BotParameters",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "BotRuns",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "Bots",
                schema: "BotsModule");
        }
    }
}
