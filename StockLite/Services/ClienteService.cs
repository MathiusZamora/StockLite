using StockLite.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace StockLite.Services
{
    public static class ClienteService
    {
        private const string CS = "Server=MENDOZAII;Database=StockLiteDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";
        private static int UsuarioActualId => FormMainMenu.UsuarioActual?.UsuarioId ?? 0;

        public static List<Cliente> GetAll()
        {
            var lista = new List<Cliente>();
            using var cn = new SqlConnection(CS);
            using var cmd = new SqlCommand("SELECT ClienteId, Nombre, Contacto, Activo FROM dbo.Cliente WHERE Activo = 1 ORDER BY Nombre", cn);
            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Cliente
                {
                    ClienteId = dr.GetInt32("ClienteId"),
                    Nombre = dr.GetString("Nombre"),
                    Contacto = dr.IsDBNull("Contacto") ? null : dr.GetString("Contacto"),
                    Activo = dr.GetBoolean("Activo")
                });
            }
            return lista;
        }

        public static void Insert(string nombre, string? contacto)
        {
            using var cn = new SqlConnection(CS);
            using var cmd = new SqlCommand("""
                INSERT INTO dbo.Cliente (Nombre, Contacto, CreadoPor, ModificadoPor)
                VALUES (@nombre, @contacto, @user, @user)
                """, cn);

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre.Trim();
            cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 100).Value = contacto?.Trim() ?? (object)DBNull.Value;
            cmd.Parameters.Add("@user", SqlDbType.Int).Value = UsuarioActualId > 0 ? UsuarioActualId : (object)DBNull.Value;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Update(int id, string nombre, string? contacto)
        {
            using var cn = new SqlConnection(CS);
            using var cmd = new SqlCommand("""
                UPDATE dbo.Cliente 
                SET Nombre = @nombre, 
                    Contacto = @contacto, 
                    ModificadoPor = @user, 
                    FechaModificacion = SYSUTCDATETIME()
                WHERE ClienteId = @id
                """, cn);

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre.Trim();
            cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 100).Value = contacto?.Trim() ?? (object)DBNull.Value;
            cmd.Parameters.Add("@user", SqlDbType.Int).Value = UsuarioActualId > 0 ? UsuarioActualId : (object)DBNull.Value;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var cn = new SqlConnection(CS);
            using var cmd = new SqlCommand("UPDATE dbo.Cliente SET Activo = 0 WHERE ClienteId = @id", cn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}