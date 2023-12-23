using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibarary.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISOfTheMonth",
                table: "Book Data",
                newName: "IsOfTheMonth");

            migrationBuilder.AddColumn<string>(
                name: "CoverPhoto",
                table: "Book Data",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPhoto",
                table: "Book Data");

            migrationBuilder.RenameColumn(
                name: "IsOfTheMonth",
                table: "Book Data",
                newName: "ISOfTheMonth");
        }
    }
}
