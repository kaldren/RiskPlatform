using System;
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BotInputFields",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FieldDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotInputFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotInputFields_Bots_BotId",
                        column: x => x.BotId,
                        principalSchema: "BotsModule",
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BotInputFiles",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotInputFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotInputFiles_Bots_BotId",
                        column: x => x.BotId,
                        principalSchema: "BotsModule",
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BotOutputFiles",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BotId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotOutputFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotOutputFiles_Bots_BotId",
                        column: x => x.BotId,
                        principalSchema: "BotsModule",
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BotScripts",
                schema: "BotsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BotId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotScripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotScripts_Bots_BotId",
                        column: x => x.BotId,
                        principalSchema: "BotsModule",
                        principalTable: "Bots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotInputFields_BotId",
                schema: "BotsModule",
                table: "BotInputFields",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_BotInputFiles_BotId",
                schema: "BotsModule",
                table: "BotInputFiles",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_BotOutputFiles_BotId",
                schema: "BotsModule",
                table: "BotOutputFiles",
                column: "BotId");

            migrationBuilder.CreateIndex(
                name: "IX_Bots_Name",
                schema: "BotsModule",
                table: "Bots",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BotScripts_BotId",
                schema: "BotsModule",
                table: "BotScripts",
                column: "BotId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotInputFields",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "BotInputFiles",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "BotOutputFiles",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "BotScripts",
                schema: "BotsModule");

            migrationBuilder.DropTable(
                name: "Bots",
                schema: "BotsModule");
        }
    }
}
