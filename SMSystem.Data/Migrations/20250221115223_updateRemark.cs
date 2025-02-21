using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateRemark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiaryId",
                table: "Remarks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Remarks_DiaryId",
                table: "Remarks",
                column: "DiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remarks_Diaries_DiaryId",
                table: "Remarks",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remarks_Diaries_DiaryId",
                table: "Remarks");

            migrationBuilder.DropIndex(
                name: "IX_Remarks_DiaryId",
                table: "Remarks");

            migrationBuilder.DropColumn(
                name: "DiaryId",
                table: "Remarks");
        }
    }
}
