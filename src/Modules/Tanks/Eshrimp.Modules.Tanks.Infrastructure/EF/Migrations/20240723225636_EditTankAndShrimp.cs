using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshrimp.Modules.Tanks.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class EditTankAndShrimp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SetUpDate",
                schema: "tanks",
                table: "Tanks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "tanks",
                table: "Tanks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Shrimps",
                schema: "tanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Species = table.Column<string>(type: "text", nullable: true),
                    TankId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shrimps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shrimps_Tanks_TankId",
                        column: x => x.TankId,
                        principalSchema: "tanks",
                        principalTable: "Tanks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shrimps_TankId",
                schema: "tanks",
                table: "Shrimps",
                column: "TankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shrimps",
                schema: "tanks");

            migrationBuilder.DropColumn(
                name: "SetUpDate",
                schema: "tanks",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "tanks",
                table: "Tanks");
        }
    }
}
