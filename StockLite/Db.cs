// Db.cs (en la raíz del proyecto)
using Microsoft.Data.SqlClient;
using System.Data;

namespace StockLite
{
    public static class Db
    {
        private const string CONNECTION_STRING =
            "Server=localhost;Database=StockLiteDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";


        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            using var cn = new SqlConnection(CONNECTION_STRING);
            using var cmd = new SqlCommand(sql, cn);
            if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
            cn.Open();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static int Exec(string sql, params SqlParameter[] parameters)
        {
            using var cn = new SqlConnection(CONNECTION_STRING);
            using var cmd = new SqlCommand(sql, cn);
            if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
            cn.Open();
                return cmd.ExecuteNonQuery();
        }

        public static object? Scalar(string sql, params SqlParameter[] parameters)
        {
            using var cn = new SqlConnection(CONNECTION_STRING);
            using var cmd = new SqlCommand(sql, cn);
            if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
            cn.Open();
            return cmd.ExecuteScalar();
        }
    }
}