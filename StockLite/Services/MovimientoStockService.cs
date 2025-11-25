using Microsoft.Data.SqlClient;
using StockLite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLite.Services
{
    public static class MovimientoStockService
    {
        private const string CS = "Server=localhost;Database=StockLiteDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";

        public static int Insert(bool esEntrada, int? clienteId, string observacion, List<DetalleMovimientoView> detalles)
        {
            using var cn = new SqlConnection(CS);
            cn.Open();
            using var tran = cn.BeginTransaction();

            try
            {
                string sqlCab = @"
                    INSERT INTO dbo.MovimientoStock (Fecha, EsEntrada, ClienteId, Observacion, CreadoPor, FechaCreacion)
                    VALUES (SYSDATETIME(), @esEntrada, @clienteId, @observacion, @creadoPor, SYSDATETIME());
                    SELECT SCOPE_IDENTITY();";

                using var cmdCab = new SqlCommand(sqlCab, cn, tran);
                cmdCab.Parameters.Add("@esEntrada", SqlDbType.Bit).Value = esEntrada;
                cmdCab.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId.HasValue ? clienteId : (object)DBNull.Value;
                cmdCab.Parameters.Add("@observacion", SqlDbType.VarChar, 300).Value = observacion ?? (object)DBNull.Value;
                cmdCab.Parameters.Add("@creadoPor", SqlDbType.Int).Value = FormMainMenu.UsuarioActual!.UsuarioId;

                int movimientoId = Convert.ToInt32(cmdCab.ExecuteScalar());

                foreach (var d in detalles)
                {
                    string sqlDet = @"
                        INSERT INTO DetalleMovimientoStock
                            (MovimientoId, ProductoId, Cantidad, PrecioCompra, PrecioVenta, CreadoPor, FechaCreacion)
                        VALUES (@movId, @prodId, @cant, @pCompra, @pVenta, @creadoPor, SYSDATETIME())";

                    using var cmdDet = new SqlCommand(sqlDet, cn, tran);
                    cmdDet.Parameters.Add("@movId", SqlDbType.Int).Value = movimientoId;
                    cmdDet.Parameters.Add("@prodId", SqlDbType.Int).Value = d.ProductoId;
                    cmdDet.Parameters.Add("@cant", SqlDbType.Int).Value = d.Cantidad;
                    cmdDet.Parameters.Add("@pCompra", SqlDbType.Float).Value = (double)d.PrecioCompra;
                    cmdDet.Parameters.Add("@pVenta", SqlDbType.Float).Value = (double)d.PrecioVenta;
                    cmdDet.Parameters.Add("@creadoPor", SqlDbType.Int).Value = FormMainMenu.UsuarioActual!.UsuarioId;

                    cmdDet.ExecuteNonQuery();

                    string sqlStock = esEntrada
                        ? "UPDATE dbo.Producto SET Stock = Stock + @cant WHERE ProductoId = @id"
                        : "UPDATE dbo.Producto SET Stock = Stock - @cant WHERE ProductoId = @id";

                    using var cmdStock = new SqlCommand(sqlStock, cn, tran);
                    cmdStock.Parameters.Add("@cant", SqlDbType.Int).Value = d.Cantidad;
                    cmdStock.Parameters.Add("@id", SqlDbType.Int).Value = d.ProductoId;
                    cmdStock.ExecuteNonQuery();
                }

                tran.Commit();
                return movimientoId;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public static List<HistorialView> GetHistorial(DateTime desde, DateTime hasta, int? productoId, int? clienteId, int? proveedorId)
        {
            var lista = new List<HistorialView>();

            const string sql = @"
    SELECT 
        m.FechaCreacion AS Fecha,
        CASE WHEN m.EsEntrada = 1 THEN 'ENTRADA' ELSE 'SALIDA' END AS Tipo,
        p.Codigo,
        p.Nombre AS Producto,
        d.Cantidad,
        ISNULL(c.Nombre, 'Sin cliente') AS Cliente,
        ISNULL(pr.Nombre, 'Sin proveedor') AS Proveedor,
        ISNULL(u.Usuario, 'Desconocido') AS Usuario,
        ISNULL(m.Observacion, '') AS Observacion
    FROM MovimientoStock m
    INNER JOIN DetalleMovimientoStock d ON m.MovimientoId = d.MovimientoId
    INNER JOIN Producto p ON d.ProductoId = p.ProductoId
    LEFT JOIN Cliente c ON m.ClienteId = c.ClienteId
    LEFT JOIN Proveedor pr ON p.ProveedorId = pr.ProveedorId
    INNER JOIN Usuario u ON m.CreadoPor = u.UsuarioId
    WHERE m.FechaCreacion >= @desde 
      AND m.FechaCreacion < DATEADD(DAY, 1, @hasta)
      AND (@productoId IS NULL OR d.ProductoId = @productoId)
      AND (@clienteId IS NULL OR m.ClienteId = @clienteId OR (m.ClienteId IS NULL AND @clienteId = 0))
      AND (@proveedorId IS NULL OR p.ProveedorId = @proveedorId)
    ORDER BY m.FechaCreacion DESC";

            using var cn = new SqlConnection(CS);
            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@desde", desde.Date);
            cmd.Parameters.AddWithValue("@hasta", hasta.Date);
            cmd.Parameters.AddWithValue("@productoId", productoId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@clienteId", clienteId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@proveedorId", proveedorId ?? (object)DBNull.Value);

            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new HistorialView
                {
                    Fecha = dr.GetDateTime("Fecha"),
                    Tipo = dr.GetString("Tipo"),
                    Codigo = dr.GetString("Codigo"),
                    Producto = dr.GetString("Producto"),
                    Cantidad = dr.GetInt32("Cantidad"),
                    Cliente = dr.GetString("Cliente"),
                    Proveedor = dr.GetString("Proveedor"),
                    Usuario = dr.GetString("Usuario"),
                    Observacion = dr.GetString("Observacion")
                });
            }

            return lista;
        }

    }
}
