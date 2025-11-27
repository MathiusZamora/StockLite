using StockLite.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace StockLite.Services
{
    public static class CategoriaService
    {
        private const string CS = "Server=localhost;Database=StockLiteDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";

        private static int UsuarioActualId => FormMainMenu.UsuarioActual?.UsuarioId ?? 0;

        public static List<Categoria> GetAll()
        {
            var lista = new List<Categoria>();
            using var cn = new SqlConnection(CS);
            using var cmd = new SqlCommand("EXEC ListarCategoria;", cn);
            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Categoria
                {
                    CategoriaId = dr.GetInt32("CategoriaId"),
                    Nombre = dr.GetString("Nombre"),
                    Activo = dr.GetBoolean("Activo")
                });
            }
            return lista;
        }

        public static void Insert(string nombre, int? creadoPor = null)
        {
            int userId = creadoPor ?? UsuarioActualId;
            using var cn = new SqlConnection(CS);
            using var cmd = new SqlCommand("""
                EXEC InsertarCategoria 
                @userId = @userId, 
                @nombre = @nombre
                """, cn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@userId", userId > 0 ? userId : (object)DBNull.Value);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Update(int id, string nombre, int? modificadoPor = null)
        {
            int userId = modificadoPor ?? UsuarioActualId;
            using var cn = new SqlConnection(CS);
            using var cmd = new SqlCommand("""
                EXEC ActualizarCategoria 
                @id = @id,
                @userId = @userId, 
                @nombre = @nombre
                """, cn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@userId", userId > 0 ? userId : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var cn = new SqlConnection(CS);
            using var cmd = new SqlCommand("EXEC AnularCategoria @id", cn);
            cmd.Parameters.AddWithValue("@id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
        }


    }
}