using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLite.Models
{
    public class MovimientoStock
    {
        public int IdMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public int? ClienteId { get; set; }
        public bool EsEntrada { get; set; }
        public string Observacion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool Activo { get; set; }
    }
}
