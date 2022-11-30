using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testing.Migrations
{
    /// <inheritdoc />
    public partial class imagecolumnInSighting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageFileName",
                table: "Sighting",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageFileName",
                table: "Sighting");
        }
    }
}
