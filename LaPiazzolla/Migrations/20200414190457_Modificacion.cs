using Microsoft.EntityFrameworkCore.Migrations;

namespace LaPiazzolla.Migrations
{
    public partial class Modificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Direcciones_ProvinciaId",
                table: "Direcciones");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_ProvinciaId",
                table: "Direcciones",
                column: "ProvinciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Direcciones_ProvinciaId",
                table: "Direcciones");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_ProvinciaId",
                table: "Direcciones",
                column: "ProvinciaId",
                unique: true);
        }
    }
}
