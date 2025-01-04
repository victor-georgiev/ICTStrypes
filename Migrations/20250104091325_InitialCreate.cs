﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICTStrypes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<string>(type: "TEXT", maxLength: 39, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "ChargePoints",
                columns: table => new
                {
                    ChargePointId = table.Column<string>(type: "TEXT", maxLength: 39, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 39, nullable: false),
                    FloorLevel = table.Column<string>(type: "TEXT", maxLength: 4, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocationId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargePoints", x => x.ChargePointId);
                    table.ForeignKey(
                        name: "FK_ChargePoints_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargePoints_LocationId",
                table: "ChargePoints",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargePoints");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
