using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LaPiazzolla.Models
{
    public class Pago
    {
        public int PagoId { get; set; }
        public float Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string Observacion { get; set; }
        public Alumno Alumno { get; set; }
    }
}
