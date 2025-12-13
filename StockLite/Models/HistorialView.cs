using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLite.Models
{
    public class HistorialView
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Proveedor { get; set; } = string.Empty; 
        public string Usuario { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
        public int MovimientoId { get; set; }
    }

}
