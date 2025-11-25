using Microsoft.Data.SqlClient;
using StockLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLite.Services
{
    public static class ProveedorService
    {
        private const string CS = "Server=localhost;Database=StockLiteDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";

        public static List<Proveedor> GetAll()
        {
            var lista = new List<Proveedor>();
            const string sql = @"
                SELECT ProveedorId, Nombre, Contacto, Telefono, Email, Activo, CreadoPor, FechaCreacion 
                FROM Proveedor 
                WHERE Activo = 1 
                ORDER BY Nombre";

            using var cn = new SqlConnection(CS);
            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Proveedor
                {
                    ProveedorId = dr.GetInt32(0),
                    Nombre = dr.GetString(1),
                    Contacto = dr.IsDBNull(2) ? null : dr.GetString(2),
                    Telefono = dr.IsDBNull(3) ? null : dr.GetString(3),
                    Email = dr.IsDBNull(4) ? null : dr.GetString(4),
                    Activo = dr.GetBoolean(5),
                    CreadoPor = dr.IsDBNull(6) ? null : dr.GetInt32(6),
                    FechaCreacion = dr.IsDBNull(7) ? null : dr.GetDateTime(7)
                });
            }
            return lista;
        }

        public static void Insert(Proveedor p)
        {
            const string sql = @"
                INSERT INTO Proveedor (Nombre, Contacto, Telefono, Email, CreadoPor, FechaCreacion, Activo)
                VALUES (@Nombre, @Contacto, @Telefono, @Email, @CreadoPor, SYSDATETIME(), 1)";

            using var cn = new SqlConnection(CS);
            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@Contacto", (object?)p.Contacto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefono", (object?)p.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)p.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreadoPor", FormMainMenu.UsuarioActual?.UsuarioId ?? 1);
            cmd.ExecuteNonQuery();
        }

        public static void Update(Proveedor p)
        {
            const string sql = @"
                UPDATE Proveedor 
                SET Nombre = @Nombre,
                    Contacto = @Contacto,
                    Telefono = @Telefono,
                    Email = @Email
                WHERE ProveedorId = @ProveedorId";

            using var cn = new SqlConnection(CS);
            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@ProveedorId", p.ProveedorId);
            cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@Contacto", (object?)p.Contacto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefono", (object?)p.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)p.Email ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        // BORRADO LÓGICO – PROFESIONAL
        public static void Delete(int proveedorId)
        {
            const string sql = "UPDATE Proveedor SET Activo = 0 WHERE ProveedorId = @id";

            using var cn = new SqlConnection(CS);
            cn.Open();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", proveedorId);
            cmd.ExecuteNonQuery();
        }
    }
}
