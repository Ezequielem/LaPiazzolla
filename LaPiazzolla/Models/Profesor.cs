using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaPiazzolla.Models
{
    public class Profesor
    {
        public int ProfesorId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public Sexo Sexo { get; set; }
        [Required]
        public Direccion Direccion { get; set; }
        [Required]
        public List<Curso> Cursos { get; set; }
    }
}
