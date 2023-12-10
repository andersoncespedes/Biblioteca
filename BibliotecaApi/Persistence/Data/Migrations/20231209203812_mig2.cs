using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_ciudad_IdCiudadFk",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_IdCiudadFk",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "user");

            migrationBuilder.DropColumn(
                name: "IdCiudadFk",
                table: "user");

            migrationBuilder.DropColumn(
                name: "IdTipoDocumento",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "user");

            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_CiudadId",
                table: "user",
                column: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_ciudad_CiudadId",
                table: "user",
                column: "CiudadId",
                principalTable: "ciudad",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_ciudad_CiudadId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_CiudadId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "user");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "user",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "user",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "user",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "IdCiudadFk",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoDocumento",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "user",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_user_IdCiudadFk",
                table: "user",
                column: "IdCiudadFk");

            migrationBuilder.AddForeignKey(
                name: "FK_user_ciudad_IdCiudadFk",
                table: "user",
                column: "IdCiudadFk",
                principalTable: "ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
