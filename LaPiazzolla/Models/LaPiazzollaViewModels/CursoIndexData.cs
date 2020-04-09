using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaPiazzolla.Models.LaPiazzollaViewModels
{
    public class CursoIndexData
    {
        public List<Curso> Cursos { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public List<Alumno_x_Curso> AlumnosCursos { get; set; }
    }
}
