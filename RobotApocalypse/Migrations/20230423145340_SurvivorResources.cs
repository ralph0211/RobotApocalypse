using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RobotApocalypse.Migrations
{
    /// <inheritdoc />
    public partial class SurvivorResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceSurvivor");

            migrationBuilder.AddColumn<long>(
                name: "SurvivorId",
                table: "Resources",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SurvivorResources",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SurvivorId = table.Column<long>(type: "INTEGER", nullable: false),
                    ResourceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurvivorResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurvivorResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurvivorResources_Survivors_SurvivorId",
                        column: x => x.SurvivorId,
                        principalTable: "Survivors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1,
                column: "SurvivorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2,
                column: "SurvivorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3,
                column: "SurvivorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4,
                column: "SurvivorId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_SurvivorId",
                table: "Resources",
                column: "SurvivorId");

            migrationBuilder.CreateIndex(
                name: "IX_SurvivorResources_ResourceId",
                table: "SurvivorResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_SurvivorResources_SurvivorId",
                table: "SurvivorResources",
                column: "SurvivorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Survivors_SurvivorId",
                table: "Resources",
                column: "SurvivorId",
                principalTable: "Survivors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Survivors_SurvivorId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "SurvivorResources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_SurvivorId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "SurvivorId",
                table: "Resources");

            migrationBuilder.CreateTable(
                name: "ResourceSurvivor",
                columns: table => new
                {
                    ResourcesId = table.Column<int>(type: "INTEGER", nullable: false),
                    SurvivorId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSurvivor", x => new { x.ResourcesId, x.SurvivorId });
                    table.ForeignKey(
                        name: "FK_ResourceSurvivor_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceSurvivor_Survivors_SurvivorId",
                        column: x => x.SurvivorId,
                        principalTable: "Survivors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSurvivor_SurvivorId",
                table: "ResourceSurvivor",
                column: "SurvivorId");
        }
    }
}
