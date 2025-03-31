using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGP.Models
{
        [Table("Egresos")]
        public class Egreso
        {
            [Key]
            public int IdEgreso { get; set; }
            [Required]
            public string Concepto { get; set; } = string.Empty;
            [Required]
            public decimal Monto { get; set; }
            [Required]
            public DateTime Fecha { get; set; }
            [Required]
            public bool Activo { get; set; }
        }
}