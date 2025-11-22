using Microsoft.Data.SqlClient;
using StockLite.Models;
using System;
using System.Collections.Generic;
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
                const string sqlCab = """
                    INSERT INTO dbo.MovimientoStock (Fecha, EsEntrada, ClienteId, Observacion, CreadoPor, FechaCreacion)
                    VALUES (SYSUTCDATETIME(), @esEntrada, @clienteId, @observacion, 1, SYSUTCDATETIME());
                    SELECT SCOPE_IDENTITY();
                    """;

                using var cmdCab = new SqlCommand(sqlCab, cn, tran);
                cmdCab.Parameters.Add("@esEntrada", System.Data.SqlDbType.Bit).Value = esEntrada;
                cmdCab.Parameters.Add("@clienteId", System.Data.SqlDbType.Int).Value = clienteId.HasValue ? clienteId : (object)DBNull.Value;
                cmdCab.Parameters.Add("@observacion", System.Data.SqlDbType.VarChar, 300).Value = observacion ?? (object)DBNull.Value;

                int movimientoId = Convert.ToInt32(cmdCab.ExecuteScalar());

                foreach (var d in detalles)
                {
                    const string sqlDet = """
                        INSERT INTO dbo.DetalleMovimientoStock 
                        (MovimientoId, ProductoId, Cantidad, PrecioCompra, PrecioVenta)
                        VALUES (@movId, @prodId, @cant, @pCompra, @pVenta)
                        """;

                    using var cmdDet = new SqlCommand(sqlDet, cn, tran);
                    cmdDet.Parameters.Add("@movId", System.Data.SqlDbType.Int).Value = movimientoId;
                    cmdDet.Parameters.Add("@prodId", System.Data.SqlDbType.Int).Value = d.ProductoId;
                    cmdDet.Parameters.Add("@cant", System.Data.SqlDbType.Int).Value = d.Cantidad;
                    cmdDet.Parameters.Add("@pCompra", System.Data.SqlDbType.Float).Value = (double)d.PrecioCompra;
                    cmdDet.Parameters.Add("@pVenta", System.Data.SqlDbType.Float).Value = (double)d.PrecioVenta;
                    cmdDet.ExecuteNonQuery();

                    string sqlStock = esEntrada
                        ? "UPDATE dbo.Producto SET Stock = Stock + @cant WHERE ProductoId = @id"
                        : "UPDATE dbo.Producto SET Stock = Stock - @cant WHERE ProductoId = @id";

                    using var cmdStock = new SqlCommand(sqlStock, cn, tran);
                    cmdStock.Parameters.Add("@cant", System.Data.SqlDbType.Int).Value = d.Cantidad;
                    cmdStock.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = d.ProductoId;
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
    }
}
