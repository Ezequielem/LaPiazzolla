using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaPiazzolla.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage ="El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; }
        [Required]        
        [Display(Name ="Precio")]
        public float PrecioMensual { get; set; }
        [Required]
        [StringLength(512, ErrorMessage ="La deescripcion puede tener 512 caracteres" )]
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }
        [Required]
        public Profesor Profesor { get; set; }
        [Required]
        public List<Alumno_x_Curso> Alumnos_X_Cursos { get; set; }
    }
}
