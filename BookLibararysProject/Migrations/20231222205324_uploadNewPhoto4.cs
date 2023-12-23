using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibarary.Migrations
{
    /// <inheritdoc />
    public partial class uploadNewPhoto4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "Book ",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Book ");
        }
    }
}
