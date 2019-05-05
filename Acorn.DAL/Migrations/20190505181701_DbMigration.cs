using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acorn.DAL.Migrations
{
    public partial class DbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bots",
                columns: table => new
                {
                    BotId = table.Column<long>(type: "INT(3)", nullable: false),
                    Nick = table.Column<string>(type: "VARCHAR(16)", nullable: false),
                    Level = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bots", x => x.BotId);
                });

            migrationBuilder.CreateTable(
                name: "FreshAccounts",
                columns: table => new
                {
                    FreshAccId = table.Column<long>(nullable: false),
                    Login = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    BirthDate = table.Column<string>(type: "DATE", nullable: false, defaultValueSql: "'1970-01-01'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreshAccounts", x => x.FreshAccId);
                });

            migrationBuilder.CreateTable(
                name: "ReadyAccounts",
                columns: table => new
                {
                    ReadyAccId = table.Column<long>(nullable: false),
                    Login = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    BirthDate = table.Column<string>(type: "DATE", nullable: false, defaultValueSql: "'1970-01-01'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadyAccounts", x => x.ReadyAccId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    BotId = table.Column<long>(type: "INT(3)", nullable: false),
                    Login = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "'login'"),
                    Password = table.Column<string>(type: "VARCHAR(25)", nullable: false, defaultValueSql: "'password'"),
                    BirthDate = table.Column<string>(type: "DATE", nullable: false, defaultValueSql: "'1970-01-01'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.BotId);
                    table.ForeignKey(
                        name: "FK_Accounts_Bots_BotId",
                        column: x => x.BotId,
                        principalTable: "Bots",
                        principalColumn: "BotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BotOrders",
                columns: table => new
                {
                    BotId = table.Column<long>(type: "INT(3)", nullable: false),
                    Order = table.Column<string>(type: "VARCHAR(10)", nullable: false, defaultValueSql: "'STOP'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotOrders", x => x.BotId);
                    table.ForeignKey(
                        name: "FK_BotOrders_Bots_BotId",
                        column: x => x.BotId,
                        principalTable: "Bots",
                        principalColumn: "BotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    BotId = table.Column<long>(type: "INT(3)", nullable: false),
                    Queuetype = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "'intro_bot'"),
                    Aiconfig = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "'follow'"),
                    Path = table.Column<string>(type: "VARCHAR(100)", nullable: false, defaultValueSql: "'C:/Riot Games/League of Legends/'"),
                    OverwriteConfig = table.Column<string>(type: "BIT(1)", nullable: false, defaultValueSql: "1"),
                    Champion1 = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "'sivir'"),
                    Champion2 = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "'missfortune'"),
                    Champion3 = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "'ashe'"),
                    Champion4 = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "'lux'"),
                    Champion5 = table.Column<string>(type: "VARCHAR(20)", nullable: false, defaultValueSql: "'annie'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.BotId);
                    table.ForeignKey(
                        name: "FK_Configs_Bots_BotId",
                        column: x => x.BotId,
                        principalTable: "Bots",
                        principalColumn: "BotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<long>(nullable: false),
                    BotId = table.Column<long>(type: "INT(3)", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Date = table.Column<string>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_Logs_Bots_BotId",
                        column: x => x.BotId,
                        principalTable: "Bots",
                        principalColumn: "BotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_BotId",
                table: "Logs",
                column: "BotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "BotOrders");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "FreshAccounts");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ReadyAccounts");

            migrationBuilder.DropTable(
                name: "Bots");
        }
    }
}
