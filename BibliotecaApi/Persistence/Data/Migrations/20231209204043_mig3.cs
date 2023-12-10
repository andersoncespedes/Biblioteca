using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_ciudad_CiudadId",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_user_tipo_documento_TipoDocumentoId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_CiudadId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_TipoDocumentoId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                table: "user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoId",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_CiudadId",
                table: "user",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_user_TipoDocumentoId",
                table: "user",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_ciudad_CiudadId",
                table: "user",
                column: "CiudadId",
                principalTable: "ciudad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_tipo_documento_TipoDocumentoId",
                table: "user",
                column: "TipoDocumentoId",
                principalTable: "tipo_documento",
                principalColumn: "Id");
        }
    }
}
