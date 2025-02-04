using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class studentClassNewChangess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_Teachers_TeacherId",
                table: "Diaries");

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

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Diaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Paralel",
                table: "Diaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_Teachers_TeacherId",
                table: "Diaries",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Diaries_DiaryId",
                table: "Students",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_Teachers_TeacherId",
                table: "Diaries");

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

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Diaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Paralel",
                table: "Diaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_Teachers_TeacherId",
                table: "Diaries",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Diaries_DiaryId",
                table: "Students",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
