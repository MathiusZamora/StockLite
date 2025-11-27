using BCrypt.Net;
using Microsoft.Data.SqlClient;
using StockLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLite.Services
{
    public static class AuthService
    {
        public static Usuario? Login(string usuario, string clave)
        {
            const string sql = """
                EXEC ValidarLogin
                @usuario = @usuario
                """;

            var dt = Db.Query(sql, new SqlParameter("@usuario", usuario));

            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            string hash = row["ClaveHash"].ToString()!;

            if (!BCrypt.Net.BCrypt.Verify(clave, hash))
                return null;

            return new Usuario
            {
                UsuarioId = Convert.ToInt32(row["UsuarioId"]),
                Nombre = row["Nombre"].ToString()!,
                NombreUsuario = row["Usuario"].ToString()!,
                Rol = row["Rol"].ToString()!,
                Activo = true
            };
        }

        public static void CrearAdminSiNoExiste()
        {
            const string sqlCheck = "EXEC CheckAdmin;";
            var existe = (int?)Db.Scalar(sqlCheck) ?? 0;

            if (existe > 0) return;

            string hash = BCrypt.Net.BCrypt.HashPassword("admin123");

            const string sqlInsert = """
                EXEC CrearAdmin
                @hash = @hash
                """;

            Db.Exec(sqlInsert, new SqlParameter("@hash", hash));
        }
    }
}
