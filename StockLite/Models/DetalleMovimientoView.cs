using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLite.Models
{
    public class DetalleMovimientoView
    {
        public int IdDetalle { get; set; }
        public int IdMovimiento { get; set; }
        public int ProductoId { get; set; }
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public int Cantidad { get; set; } = 1;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Subtotal => Cantidad * (EsEntrada ? PrecioCompra : PrecioVenta);
        public int IdUsuarioRegistro { get; set; }


        // Solo para saber si es entrada o salida al calcular subtotal
        public bool EsEntrada { get; set; }
    }
}
