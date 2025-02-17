using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AbsenceAndEvaluationRelationWithDiary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiaryId",
                table: "Evaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiaryId",
                table: "Absences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_DiaryId",
                table: "Evaluations",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_DiaryId",
                table: "Absences",
                column: "DiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Diaries_DiaryId",
                table: "Absences",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Diaries_DiaryId",
                table: "Evaluations",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Diaries_DiaryId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Diaries_DiaryId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_DiaryId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Absences_DiaryId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "DiaryId",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "DiaryId",
                table: "Absences");
        }
    }
}
