using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RobotApocalypse.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Survivors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    IsInfected = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastLocationLatitude = table.Column<double>(type: "REAL", nullable: false),
                    LastLocationLongitude = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survivors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportedInfections",
                columns: table => new
                {
                    ReporterId = table.Column<long>(type: "INTEGER", nullable: false),
                    InfectedSurvivorId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedInfections", x => new { x.ReporterId, x.InfectedSurvivorId });
                    table.ForeignKey(
                        name: "FK_ReportedInfections_Survivors_InfectedSurvivorId",
                        column: x => x.InfectedSurvivorId,
                        principalTable: "Survivors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportedInfections_Survivors_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "Survivors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Water" },
                    { 2, "Food" },
                    { 3, "Medication" },
                    { 4, "Ammunition" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportedInfections_InfectedSurvivorId",
                table: "ReportedInfections",
                column: "InfectedSurvivorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSurvivor_SurvivorId",
                table: "ResourceSurvivor",
                column: "SurvivorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportedInfections");

            migrationBuilder.DropTable(
                name: "ResourceSurvivor");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Survivors");
        }
    }
}
