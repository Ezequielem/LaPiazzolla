using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaPiazzolla.Models
{
    public class Alumno_x_Curso
    {
        public int AlumnoId { get; set; }
        public int CursoId { get; set; }
        [Required]
        public Alumno Alumno { get; set; }
        [Required]
        public Curso Curso { get; set; }
    }
}
