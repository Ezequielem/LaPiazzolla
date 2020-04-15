using Microsoft.EntityFrameworkCore.Migrations;

namespace LaPiazzolla.Migrations
{
    public partial class Modifica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direcciones_Provincias_ProvinciaId",
                table: "Direcciones");

            migrationBuilder.DropIndex(
                name: "IX_Direcciones_ProvinciaId",
                table: "Direcciones");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Direcciones");

            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "Direcciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_LocalidadId",
                table: "Direcciones",
                column: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Direcciones_Localidades_LocalidadId",
                table: "Direcciones",
                column: "LocalidadId",
                principalTable: "Localidades",
                principalColumn: "LocalidadId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direcciones_Localidades_LocalidadId",
                table: "Direcciones");

            migrationBuilder.DropIndex(
                name: "IX_Direcciones_LocalidadId",
                table: "Direcciones");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "Direcciones");

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Direcciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_ProvinciaId",
                table: "Direcciones",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Direcciones_Provincias_ProvinciaId",
                table: "Direcciones",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
