using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentDiaryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Diaries_DiaryId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "DiaryId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Diaries_DiaryId",
                table: "Students",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Diaries_DiaryId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "DiaryId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Diaries_DiaryId",
                table: "Students",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id");
        }
    }
}
