using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibarary.Migrations
{
    /// <inheritdoc />
    public partial class uploadNewPhoto3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPhotoContentType",
                table: "Book ");

            migrationBuilder.DropColumn(
                name: "CoverPhotoData",
                table: "Book ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverPhotoContentType",
                table: "Book ",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CoverPhotoData",
                table: "Book ",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
