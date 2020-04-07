using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaPiazzolla.Models
{
    public class Direccion
    {
        public int DireccionId { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string Altura { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        [Required]
        public string CodigoPostal { get; set; }
        [Required]
        public string Localidad{ get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Pais { get; set; }

    }
}
