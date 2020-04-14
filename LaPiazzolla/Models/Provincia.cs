using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaPiazzolla.Models
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        public List<Departamento> Departamentos { get; set; }
        public Direccion Direccion { get; set; }
    }
}
