using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseKeepingAccounting.DAL.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    HomeNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FactoryNumber = table.Column<string>(nullable: true),
                    VerificationTimeOver = table.Column<DateTime>(nullable: false),
                    HouseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counters_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Indications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PreviousIndication = table.Column<int>(nullable: false),
                    CurrentIndication = table.Column<int>(nullable: false),
                    FillingTime = table.Column<DateTime>(nullable: false),
                    CounterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indications_Counters_CounterId",
                        column: x => x.CounterId,
                        principalTable: "Counters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Counters_HouseId",
                table: "Counters",
                column: "HouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CityName_HomeNumber_StreetName",
                table: "Houses",
                columns: new[] { "CityName", "HomeNumber", "StreetName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Indications_CounterId",
                table: "Indications",
                column: "CounterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indications");

            migrationBuilder.DropTable(
                name: "Counters");

            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
