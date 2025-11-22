// Models/Producto.cs
namespace StockLite.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; } = string.Empty;

        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }

        public int StockActual { get; set; }

        public bool Activo { get; set; } = true;

        public string CodigoNombre => $"{Codigo} - {Nombre}";
    }
}