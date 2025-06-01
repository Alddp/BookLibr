using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDAL
{
    public static class DBHelper
    {
        private const string database = "LibrBook";
        private static readonly string connectionString =
            $"Data Source=.\\SQLEXPRESS; Initial Catalog={database}; Integrated Security=true";

        // 获取单值（无参数）
        public static int ExScalar(string sql)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // 获取单值（带参数）
        public static int ExScalar(string sql, params SqlParameter[] para)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (para != null)
                    cmd.Parameters.AddRange(para);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // 执行非查询（无参数）
        public static int ExNonQuery(string sql)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 执行非查询（带参数）
        public static int ExNonQuery(string sql, params SqlParameter[] para)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (para != null)
                    cmd.Parameters.AddRange(para);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 查询结果（返回 DataReader，调用者使用 using 包裹）
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] para)
        {
            var conn = new SqlConnection(connectionString);
            var cmd = new SqlCommand(sql, conn);
            if (para != null)
                cmd.Parameters.AddRange(para);
            conn.Open();
            // 使用 CommandBehavior.CloseConnection 保证 reader.Close() 时也关闭连接
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
