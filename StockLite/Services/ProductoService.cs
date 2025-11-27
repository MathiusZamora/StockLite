using Microsoft.Data.SqlClient;
using StockLite.Models;
using System.Data;

namespace StockLite.Services
{
    public static class ProductoService
    {
        private const string CS = "Server=localhost;Database=StockLiteDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";

        public static List<Producto> GetAll()
        {
            var lista = new List<Producto>();
            using var cn = new SqlConnection(CS);
            cn.Open();

            const string sql = @"
            EXEC ListarProducto;";

            using var cmd = new SqlCommand(sql, cn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Producto
                {
                    ProductoId = dr.GetInt32("ProductoId"),
                    Codigo = dr.GetString("Codigo"),
                    Nombre = dr.GetString("Nombre"),
                    CategoriaId = dr.GetInt32("CategoriaId"),
                    CategoriaNombre = dr.IsDBNull("CategoriaNombre") ? "Sin categoría" : dr.GetString("CategoriaNombre"),
                    PrecioCosto = Convert.ToDecimal(dr["PrecioCosto"]),
                    PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                    StockActual = dr.GetInt32("StockActual"),
                    ProveedorId = dr.IsDBNull("ProveedorId") ? (int?)null : dr.GetInt32("ProveedorId"),
                    ProveedorNombre = dr.IsDBNull("ProveedorNombre") ? null : dr.GetString("ProveedorNombre")
                });
            }
            return lista;
        }

        public static void Insert(string codigo, string nombre, int categoriaId, decimal costoActual, decimal precio, int? proveedorId)
        {
            const string sql = @"
            EXEC InsertarProducto
            @codigo = @codigo,
            @nombre = @nombre,
            @categoriaId = @categoriaId,
            @costoActual = @costoActual,
            @precio = @precio,
            @proveedorId = @proveedorId,
            @creadoPor = @creadoPor
            ";

            using var cn = new SqlConnection(CS);
            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@categoriaId", categoriaId);
            cmd.Parameters.AddWithValue("@costoActual", costoActual);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@proveedorId", (object?)proveedorId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@creadoPor", FormMainMenu.UsuarioActual?.UsuarioId ?? 1);
            cmd.ExecuteNonQuery();
        }

        public static void Update(int productoId, string codigo, string nombre, int categoriaId, decimal costoActual, decimal precio, int? proveedorId, int modificadoPor)
        {
            const string sql = @"
            EXEC ActualizarProducto
            @productoId = @productoId,
            @nombre = @nombre,
            @categoriaId = @categoriaId,
            @costoActual = @costoActual,
            @precio = @precio,
            @proveedorId = @proveedorId,
            @modificadopor = @modificadopor";

            using var cn = new SqlConnection(CS);
            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@productoId", productoId);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@categoriaId", categoriaId);
            cmd.Parameters.AddWithValue("@costoActual", costoActual);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@proveedorId", (object?)proveedorId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@modificadoPor", modificadoPor);
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var cn = new SqlConnection(CS);
            cn.Open();
            using var cmd = new SqlCommand("EXEC AnularProducto @id = @id", cn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }

        public static string ObtenerSiguienteCodigo()
        {
            const string sql = @"
        SELECT ISNULL(MAX(ProductoId), 0) + 1 
        FROM Producto WITH (UPDLOCK, ROWLOCK, READPAST)";

            using var cn = new SqlConnection(CS);
            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            int siguienteId = (int)cmd.ExecuteScalar();
            return "PRD-" + siguienteId.ToString("D5");
        }

    }
}