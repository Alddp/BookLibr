using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDAL
{
    public class DBHelper
    {
        private static SqlConnection connection;

        public static SqlConnection Connection
        {
            get
            {
                const string database = "LibrBook";
                string constring = $"Data Source=.\\SQLEXPRESS; Initial Catalog={database}; Integrated Security=true";

                if (connection == null)
                {
                    connection = new SqlConnection(constring);
                    connection.Open();
                }

                else if (connection.State == ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }

                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                return connection;
            }
        }

        // 执行标量查询方法，用于多次调用
        // 适用于需要获取单个值的查询，如聚合查询或获取某个特定字段的值
        public static int ExScalar(string sql)
        {
            SqlCommand c = new SqlCommand(sql, DBHelper.Connection);
            int i = (int)c.ExecuteScalar();
            return i;
        }

        // 执行标量查询方法，用于多次调用
        // 适用于需要获取单个值的查询，如聚合查询或获取某个特定字段的值
        public static int ExScalar(string sql, params SqlParameter[] parameters)
        {
            SqlCommand c = new SqlCommand(sql, DBHelper.Connection);
            if (parameters != null)
                c.Parameters.AddRange(parameters);
            return (int)c.ExecuteScalar();
        }

        // 改写 ExecuteNonQuery 方法，用于多次调用（增删改操作）
        // 适用于不需要返回任何结果集的命令，如 INSERT、UPDATE、DELETE 等
        public static int ExNonQuery(string sql)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            return c.ExecuteNonQuery();
        }

        // 带参数的 ExecuteNonQuery 方法
        public static int ExNonQuery(string sql, params SqlParameter[] para)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            c.Parameters.AddRange(para);
            return c.ExecuteNonQuery();
        }

        // 执行查询方法，用于多次调用（查询操作）
        // 适用于需要返回结果集的命令，如 SELECT 等
        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            return c.ExecuteReader();
        }

        // 带参数的 ExecuteReader 方法
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            if (parameters != null)
                c.Parameters.AddRange(parameters);
            return c.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
