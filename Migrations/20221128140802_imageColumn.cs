using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testing.Migrations
{
    /// <inheritdoc />
    public partial class imageColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Person_OwnerId",
                table: "Cat");

            migrationBuilder.AddColumn<string>(
                name: "imageFileName",
                table: "Wanting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Cat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Person_OwnerId",
                table: "Cat",
                column: "OwnerId",
                principalTable: "Person",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Person_OwnerId",
                table: "Cat");

            migrationBuilder.DropColumn(
                name: "imageFileName",
                table: "Wanting");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Cat",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Person_OwnerId",
                table: "Cat",
                column: "OwnerId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
