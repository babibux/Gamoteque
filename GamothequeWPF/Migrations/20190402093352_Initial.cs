using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GamothequeWPF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Done = table.Column<bool>(nullable: false),
                    Synopsis = table.Column<string>(nullable: true),
                    Review = table.Column<string>(nullable: true),
                    Mark = table.Column<int>(nullable: false),
                    MinimumAge = table.Column<int>(nullable: false),
                    PhysicalSupport = table.Column<bool>(nullable: false),
                    DigitalSupport = table.Column<bool>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    ExpectedDuration = table.Column<TimeSpan>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTextLanguage",
                columns: table => new
                {
                    IdGame = table.Column<int>(nullable: false),
                    NameLanguage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTextLanguage", x => new { x.IdGame, x.NameLanguage });
                    table.ForeignKey(
                        name: "FK_GameTextLanguage_Game_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTextLanguage_Language_NameLanguage",
                        column: x => x.NameLanguage,
                        principalTable: "Language",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameVoiceLanguage",
                columns: table => new
                {
                    IdGame = table.Column<int>(nullable: false),
                    NameLanguage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameVoiceLanguage", x => new { x.IdGame, x.NameLanguage });
                    table.ForeignKey(
                        name: "FK_GameVoiceLanguage_Game_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameVoiceLanguage_Language_NameLanguage",
                        column: x => x.NameLanguage,
                        principalTable: "Language",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameType",
                columns: table => new
                {
                    IdType = table.Column<int>(nullable: false),
                    IdGame = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameType", x => new { x.IdGame, x.IdType });
                    table.ForeignKey(
                        name: "FK_GameType_Game_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameType_Type_IdType",
                        column: x => x.IdType,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTextLanguage_NameLanguage",
                table: "GameTextLanguage",
                column: "NameLanguage");

            migrationBuilder.CreateIndex(
                name: "IX_GameType_IdType",
                table: "GameType",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_GameVoiceLanguage_NameLanguage",
                table: "GameVoiceLanguage",
                column: "NameLanguage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTextLanguage");

            migrationBuilder.DropTable(
                name: "GameType");

            migrationBuilder.DropTable(
                name: "GameVoiceLanguage");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
