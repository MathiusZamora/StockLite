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
                SELECT  p.ProductoId,
                        p.Codigo,
                        p.Nombre,
                        p.CategoriaId,
                        c.Nombre AS CategoriaNombre,
                        p.CostoActual  AS PrecioCosto,
                        p.PrecioActual AS PrecioVenta,
                        p.Stock        AS StockActual
                FROM dbo.Producto p
                LEFT JOIN dbo.Categoria c ON p.CategoriaId = c.CategoriaId
                WHERE p.Activo = 1
                ORDER BY p.Nombre";

            using var cmd = new SqlCommand(sql, cn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Producto
                {
                    ProductoId      = dr.GetInt32("ProductoId"),
                    Codigo          = dr.GetString("Codigo"),
                    Nombre          = dr.GetString("Nombre"),
                    CategoriaId     = dr.GetInt32("CategoriaId"),
                    CategoriaNombre = dr.IsDBNull("CategoriaNombre") ? "Sin categoría" : dr.GetString("CategoriaNombre"),
                    PrecioCosto     = Convert.ToDecimal(dr["PrecioCosto"]),  
                    PrecioVenta     = Convert.ToDecimal(dr["PrecioVenta"]),  
                    StockActual     = dr.GetInt32("StockActual")
                });
            }
            return lista;
        }

        public static void Insert(string codigo, string nombre, int categoriaId, decimal costo, decimal precioVenta)
        {
            using var cn = new SqlConnection(CS);
            const string sql = @"
                INSERT INTO Producto (Codigo, Nombre, CategoriaId, CostoActual, PrecioActual, Stock, Activo, CreadoPor, FechaCreacion)
                VALUES (@cod, @nom, @cat, @costo, @precio, 0, 1, 1, SYSDATETIME())";

            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@cod", SqlDbType.VarChar, 50).Value = codigo.Trim();
            cmd.Parameters.Add("@nom", SqlDbType.VarChar, 200).Value = nombre.Trim();
            cmd.Parameters.Add("@cat", SqlDbType.Int).Value = categoriaId;
            cmd.Parameters.Add("@costo", SqlDbType.Float).Value = (double)costo;     
            cmd.Parameters.Add("@precio", SqlDbType.Float).Value = (double)precioVenta; 
            cmd.ExecuteNonQuery();
        }

        public static void Update(int id, string codigo, string nombre, int categoriaId, decimal costo, decimal precioVenta)
        {
            using var cn = new SqlConnection(CS);
            const string sql = @"
                UPDATE Producto 
                SET Codigo = @cod, Nombre = @nom, CategoriaId = @cat,
                    CostoActual = @costo, PrecioActual = @precio
                WHERE ProductoId = @id";

            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@cod", SqlDbType.VarChar, 50).Value = codigo.Trim();
            cmd.Parameters.Add("@nom", SqlDbType.VarChar, 200).Value = nombre.Trim();
            cmd.Parameters.Add("@cat", SqlDbType.Int).Value = categoriaId;
            cmd.Parameters.Add("@costo", SqlDbType.Float).Value = (double)costo;
            cmd.Parameters.Add("@precio", SqlDbType.Float).Value = (double)precioVenta;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var cn = new SqlConnection(CS);
            cn.Open();
            using var cmd = new SqlCommand("UPDATE Producto SET Activo = 0 WHERE ProductoId = @id", cn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }
    }
}