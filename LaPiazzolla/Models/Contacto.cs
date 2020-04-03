using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaPiazzolla.Models
{
    public class Contacto
    {
        public int ContactoId { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage ="El nombre debe tener entre 3 y 5 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El apellido debe tener entre 3 y 5 caracteres")]
        public string Apellido { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(512, ErrorMessage = "El mensaje debe tener hasta 512 caracteres")]
        public string Mensaje { get; set; }

    }
}
