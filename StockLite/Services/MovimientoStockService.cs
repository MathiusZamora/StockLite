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
                    EXEC InsertarMovimientoStock
                    @esEntrada = @esEntrada,
                    @clienteId = @clienteId,
                    @observacion = @observacion,
                    @creadoPor = @creadoPor
                    ";

                using var cmdCab = new SqlCommand(sqlCab, cn, tran);
                cmdCab.Parameters.Add("@esEntrada", SqlDbType.Bit).Value = esEntrada;
                cmdCab.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId.HasValue ? clienteId : (object)DBNull.Value;
                cmdCab.Parameters.Add("@observacion", SqlDbType.VarChar, 300).Value = observacion ?? (object)DBNull.Value;
                cmdCab.Parameters.Add("@creadoPor", SqlDbType.Int).Value = FormMainMenu.UsuarioActual!.UsuarioId;

                int movimientoId = Convert.ToInt32(cmdCab.ExecuteScalar());

                foreach (var d in detalles)
                {
                    string sqlDet = @"
                        EXEC InsertarDetalleMovimientoStock
                        @movId = @movId,
                        @prodId = @prodId,
                        @cant = @cant,
                        @pCompra = @pCompra,
                        @pVenta = @pVenta,
                        @creadoPor = @creadoPor
                        ";

                    using var cmdDet = new SqlCommand(sqlDet, cn, tran);
                    cmdDet.Parameters.Add("@movId", SqlDbType.Int).Value = movimientoId;
                    cmdDet.Parameters.Add("@prodId", SqlDbType.Int).Value = d.ProductoId;
                    cmdDet.Parameters.Add("@cant", SqlDbType.Int).Value = d.Cantidad;
                    cmdDet.Parameters.Add("@pCompra", SqlDbType.Float).Value = (double)d.PrecioCompra;
                    cmdDet.Parameters.Add("@pVenta", SqlDbType.Float).Value = (double)d.PrecioVenta;
                    cmdDet.Parameters.Add("@creadoPor", SqlDbType.Int).Value = FormMainMenu.UsuarioActual!.UsuarioId;

                    cmdDet.ExecuteNonQuery();

                    string sqlStock = esEntrada
                        ? "EXEC SumarStock @cant = @cant, @id = @id"
                        : "EXEC RestarStock @cant = @cant, @id = @id";

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
    
            EXEC BuscarHistorial
            @desde = @desde,
            @hasta = @hasta,
            @productoId = @productoId,
            @clienteId = @clienteId,
            @proveedorId = @proveedorId

            ";

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
