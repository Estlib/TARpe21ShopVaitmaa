using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe21ShopVaitmaa.Data.Migrations
{
    public partial class removeddimensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dimension");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spaceships",
                table: "spaceships");

            migrationBuilder.RenameTable(
                name: "spaceships",
                newName: "Spaceships");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spaceships",
                table: "Spaceships",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Spaceships",
                table: "Spaceships");

            migrationBuilder.RenameTable(
                name: "Spaceships",
                newName: "spaceships");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spaceships",
                table: "spaceships",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Dimension",
                columns: table => new
                {
                    DimensionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Depth = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    SpaceshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimension", x => x.DimensionID);
                    table.ForeignKey(
                        name: "FK_Dimension_spaceships_SpaceshipId",
                        column: x => x.SpaceshipId,
                        principalTable: "spaceships",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dimension_SpaceshipId",
                table: "Dimension",
                column: "SpaceshipId");
        }
    }
}
