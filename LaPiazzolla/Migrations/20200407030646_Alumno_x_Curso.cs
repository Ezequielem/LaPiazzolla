using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaPiazzolla.Migrations
{
    public partial class Alumno_x_Curso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos_X_Cursos",
                columns: table => new
                {
                    AlumnoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    FechaInscripcion = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    Observacion = table.Column<string>(maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos_X_Cursos", x => new { x.AlumnoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_Alumnos_X_Cursos_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "AlumnoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alumnos_X_Cursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_X_Cursos_CursoId",
                table: "Alumnos_X_Cursos",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos_X_Cursos");
        }
    }
}
