using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGP.Models
{
        [Table("Ingresos")]
        public class Ingreso
        {
            [Key]
            public int IdIngreso { get; set; }
            [Required]
            public string Concepto { get; set; } = string.Empty;
            public decimal Monto { get; set; }
            public DateTime Fecha { get; set; }
            public bool Activo { get; set; }
        }
}