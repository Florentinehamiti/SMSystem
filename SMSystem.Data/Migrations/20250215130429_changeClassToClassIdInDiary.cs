using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeClassToClassIdInDiary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Diaries",
                newName: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Diaries_ClassId",
                table: "Diaries",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_Classes_ClassId",
                table: "Diaries",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_Classes_ClassId",
                table: "Diaries");

            migrationBuilder.DropIndex(
                name: "IX_Diaries_ClassId",
                table: "Diaries");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Diaries",
                newName: "Class");
        }
    }
}
