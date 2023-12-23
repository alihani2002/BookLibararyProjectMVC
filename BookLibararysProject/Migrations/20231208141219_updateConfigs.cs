using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibarary.Migrations
{
    /// <inheritdoc />
    public partial class updateConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book Data_Categories Table_CategoryId",
                table: "Book Data");

            migrationBuilder.RenameTable(
                name: "Categories Table",
                newName: "Categories ");

            migrationBuilder.RenameTable(
                name: "Book Data",
                newName: "Book ");

            migrationBuilder.RenameIndex(
                name: "IX_Book Data_CategoryId",
                table: "Book ",
                newName: "IX_Book _CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book _Categories _CategoryId",
                table: "Book ",
                column: "CategoryId",
                principalTable: "Categories ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book _Categories _CategoryId",
                table: "Book ");

            migrationBuilder.RenameTable(
                name: "Categories ",
                newName: "Categories Table");

            migrationBuilder.RenameTable(
                name: "Book ",
                newName: "Book Data");

            migrationBuilder.RenameIndex(
                name: "IX_Book _CategoryId",
                table: "Book Data",
                newName: "IX_Book Data_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book Data_Categories Table_CategoryId",
                table: "Book Data",
                column: "CategoryId",
                principalTable: "Categories Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
