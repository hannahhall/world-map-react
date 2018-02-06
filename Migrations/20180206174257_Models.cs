using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WorldMapApi.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    ContinentId = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.ContinentId);
                });

            migrationBuilder.CreateTable(
                name: "SubRegion",
                columns: table => new
                {
                    SubRegionId = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ContinentId = table.Column<int>(type: "int4", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRegion", x => x.SubRegionId);
                    table.ForeignKey(
                        name: "FK_SubRegion_Continent_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continent",
                        principalColumn: "ContinentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Capital = table.Column<string>(type: "text", nullable: false),
                    ContinentId = table.Column<int>(type: "int4", nullable: false),
                    Coordinates = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SubRegionId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Country_Continent_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continent",
                        principalColumn: "ContinentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Country_SubRegion_SubRegionId",
                        column: x => x.SubRegionId,
                        principalTable: "SubRegion",
                        principalColumn: "SubRegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    StatsId = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountryId = table.Column<int>(type: "int4", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Success = table.Column<int>(type: "int4", nullable: false),
                    Tries = table.Column<int>(type: "int4", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.StatsId);
                    table.ForeignKey(
                        name: "FK_Stats_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stats_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_ContinentId",
                table: "Country",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_SubRegionId",
                table: "Country",
                column: "SubRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_CountryId",
                table: "Stats",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_UserId",
                table: "Stats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubRegion_ContinentId",
                table: "SubRegion",
                column: "ContinentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "SubRegion");

            migrationBuilder.DropTable(
                name: "Continent");
        }
    }
}
