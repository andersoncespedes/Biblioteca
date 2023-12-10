using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_libro_author_AuthorId",
                table: "libro");

            migrationBuilder.DropIndex(
                name: "IX_libro_AuthorId",
                table: "libro");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "libro");

            migrationBuilder.CreateIndex(
                name: "IX_libro_IdAutor",
                table: "libro",
                column: "IdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_libro_author_IdAutor",
                table: "libro",
                column: "IdAutor",
                principalTable: "author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_libro_author_IdAutor",
                table: "libro");

            migrationBuilder.DropIndex(
                name: "IX_libro_IdAutor",
                table: "libro");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "libro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_libro_AuthorId",
                table: "libro",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_libro_author_AuthorId",
                table: "libro",
                column: "AuthorId",
                principalTable: "author",
                principalColumn: "Id");
        }
    }
}
