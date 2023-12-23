using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibarary.Migrations
{
    /// <inheritdoc />
    public partial class CreateApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CategoryID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ISOfTheMonth = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BookId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book Data_Categories Table_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book Data_CategoryId",
                table: "Book Data",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book Data");

            migrationBuilder.DropTable(
                name: "Categories Table");
        }
    }
}
