using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaPiazzolla.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }
        [Required]
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
    }
}
