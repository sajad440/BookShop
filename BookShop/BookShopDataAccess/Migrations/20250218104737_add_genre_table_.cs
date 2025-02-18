using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_genre_table_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_GenreId",
                table: "books",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_genres_GenreId",
                table: "books",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_genres_GenreId",
                table: "books");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropIndex(
                name: "IX_books_GenreId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "books");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
