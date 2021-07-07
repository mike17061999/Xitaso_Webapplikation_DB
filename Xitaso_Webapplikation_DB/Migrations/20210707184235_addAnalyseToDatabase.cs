using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xitaso_Webapplikation_DB.Migrations
{
    public partial class addAnalyseToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectDescription",
                table: "Projekte",
                newName: "projectDescription");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projekte",
                newName: "name");

            migrationBuilder.CreateTable(
                name: "Analysen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projectId = table.Column<int>(type: "int", nullable: false),
                    ProjektId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analysen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analysen_Projekte_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Analysekategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    analyseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analysekategorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analysekategorie_Analysen_analyseId",
                        column: x => x.analyseId,
                        principalTable: "Analysen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    istBewertung = table.Column<int>(type: "int", nullable: false),
                    SollBewertung = table.Column<int>(type: "int", nullable: false),
                    analyseKategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frage_Analysekategorie_analyseKategorieId",
                        column: x => x.analyseKategorieId,
                        principalTable: "Analysekategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analysekategorie_analyseId",
                table: "Analysekategorie",
                column: "analyseId");

            migrationBuilder.CreateIndex(
                name: "IX_Analysen_ProjektId",
                table: "Analysen",
                column: "ProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_Frage_analyseKategorieId",
                table: "Frage",
                column: "analyseKategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frage");

            migrationBuilder.DropTable(
                name: "Analysekategorie");

            migrationBuilder.DropTable(
                name: "Analysen");

            migrationBuilder.RenameColumn(
                name: "projectDescription",
                table: "Projekte",
                newName: "ProjectDescription");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Projekte",
                newName: "Name");
        }
    }
}
