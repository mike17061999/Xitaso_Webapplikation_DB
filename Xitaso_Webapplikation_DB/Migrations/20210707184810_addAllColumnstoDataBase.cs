using Microsoft.EntityFrameworkCore.Migrations;

namespace Xitaso_Webapplikation_DB.Migrations
{
    public partial class addAllColumnstoDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analysekategorie_Analysen_analyseId",
                table: "Analysekategorie");

            migrationBuilder.DropForeignKey(
                name: "FK_Frage_Analysekategorie_analyseKategorieId",
                table: "Frage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Frage",
                table: "Frage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Analysekategorie",
                table: "Analysekategorie");

            migrationBuilder.RenameTable(
                name: "Frage",
                newName: "Fragen");

            migrationBuilder.RenameTable(
                name: "Analysekategorie",
                newName: "Analysekategorien");

            migrationBuilder.RenameIndex(
                name: "IX_Frage_analyseKategorieId",
                table: "Fragen",
                newName: "IX_Fragen_analyseKategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_Analysekategorie_analyseId",
                table: "Analysekategorien",
                newName: "IX_Analysekategorien_analyseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fragen",
                table: "Fragen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Analysekategorien",
                table: "Analysekategorien",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Analysekategorien_Analysen_analyseId",
                table: "Analysekategorien",
                column: "analyseId",
                principalTable: "Analysen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fragen_Analysekategorien_analyseKategorieId",
                table: "Fragen",
                column: "analyseKategorieId",
                principalTable: "Analysekategorien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analysekategorien_Analysen_analyseId",
                table: "Analysekategorien");

            migrationBuilder.DropForeignKey(
                name: "FK_Fragen_Analysekategorien_analyseKategorieId",
                table: "Fragen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fragen",
                table: "Fragen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Analysekategorien",
                table: "Analysekategorien");

            migrationBuilder.RenameTable(
                name: "Fragen",
                newName: "Frage");

            migrationBuilder.RenameTable(
                name: "Analysekategorien",
                newName: "Analysekategorie");

            migrationBuilder.RenameIndex(
                name: "IX_Fragen_analyseKategorieId",
                table: "Frage",
                newName: "IX_Frage_analyseKategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_Analysekategorien_analyseId",
                table: "Analysekategorie",
                newName: "IX_Analysekategorie_analyseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Frage",
                table: "Frage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Analysekategorie",
                table: "Analysekategorie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Analysekategorie_Analysen_analyseId",
                table: "Analysekategorie",
                column: "analyseId",
                principalTable: "Analysen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frage_Analysekategorie_analyseKategorieId",
                table: "Frage",
                column: "analyseKategorieId",
                principalTable: "Analysekategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
