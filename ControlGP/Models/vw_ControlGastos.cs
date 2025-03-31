using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGP.Models
{
    [Table("vw_ControlGastos")]
    public class ControlGasto
    {
        [Key]
        public long Id { get; set; } // Cambiar a long
        public string Concepto { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = string.Empty;
    }
}
