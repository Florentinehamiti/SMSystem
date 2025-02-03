using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class changesAdrressId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_Addresses_AddressId",
                table: "Diaries");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Diaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_Addresses_AddressId",
                table: "Diaries",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_Addresses_AddressId",
                table: "Diaries");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Diaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_Addresses_AddressId",
                table: "Diaries",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
