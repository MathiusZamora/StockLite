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
            const string sql = """
                SELECT p.ProductoId,
                       p.Codigo,
                       p.Nombre,
                       p.CategoriaId,
                       c.Nombre AS CategoriaNombre,
                       p.CostoActual,
                       p.PrecioActual AS PrecioVenta,
                       p.Stock,
                       p.Activo
                FROM dbo.Producto p
                LEFT JOIN dbo.Categoria c ON p.CategoriaId = c.CategoriaId
                WHERE p.Activo = 1
                ORDER BY p.Nombre
                """;

            using var cmd = new SqlCommand(sql, cn);
            cn.Open();
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
                    PrecioCosto = (decimal)dr.GetDouble("CostoActual"),
                    PrecioVenta = (decimal)dr.GetDouble("PrecioVenta"),
                    StockActual = dr.GetInt32("Stock"),
                    Activo = dr.GetBoolean("Activo")
                });
            }
            return lista;
        }

        public static void Insert(string codigo, string nombre, int categoriaId, decimal costo, decimal precioVenta)
        {
            using var cn = new SqlConnection(CS);
            const string sql = """
                INSERT INTO dbo.Producto 
                (Codigo, Nombre, CategoriaId, CostoActual, PrecioActual, PrecioVenta, Stock, Activo)
                VALUES 
                (@codigo, @nombre, @categoriaId, @costo, @precioVenta, @precioVenta, 0, 1)
                """;
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 50).Value = codigo.Trim();
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = nombre.Trim();
            cmd.Parameters.Add("@categoriaId", SqlDbType.Int).Value = categoriaId;
            cmd.Parameters.Add("@costo", SqlDbType.Float).Value = (double)costo;
            cmd.Parameters.Add("@precioVenta", SqlDbType.Float).Value = (double)precioVenta;
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Update(int id, string codigo, string nombre, int categoriaId, decimal costo, decimal precioVenta)
        {
            using var cn = new SqlConnection(CS);
            const string sql = """
                UPDATE dbo.Producto
                SET Codigo = @codigo,
                    Nombre = @nombre,
                    CategoriaId = @categoriaId,
                    CostoActual = @costo,
                    PrecioActual = @precioVenta,
                    PrecioVenta = @precioVenta
                WHERE ProductoId = @id
                """;
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 50).Value = codigo.Trim();
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = nombre.Trim();
            cmd.Parameters.Add("@categoriaId", SqlDbType.Int).Value = categoriaId;
            cmd.Parameters.Add("@costo", SqlDbType.Float).Value = (double)costo;
            cmd.Parameters.Add("@precioVenta", SqlDbType.Float).Value = (double)precioVenta;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var cn = new SqlConnection(CS);
            using var cmd = new SqlCommand("UPDATE dbo.Producto SET Activo = 0 WHERE ProductoId = @id", cn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}