using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class schoolHourChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolHourDescribe",
                table: "SchoolHours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolHourDescribe",
                table: "SchoolHours");
        }
    }
}
