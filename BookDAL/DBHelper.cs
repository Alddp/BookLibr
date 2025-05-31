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

        /// <summary>
        /// 用于需要获取单个值的查询，如聚合查询或获取某个特定字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExScalar(string sql)
        {
            SqlCommand c = new SqlCommand(sql, DBHelper.Connection);
            int i = (int)c.ExecuteScalar();
            return i;
        }

        /// <summary>
        /// 执行标量查询方法，用于多次调用
        /// 用于需要获取单个值的查询，如聚合查询或获取某个特定字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static int ExScalar(string sql, params SqlParameter[] para)
        {
            SqlCommand c = new SqlCommand(sql, DBHelper.Connection);
            if (para != null)
                c.Parameters.AddRange(para);
            return (int)c.ExecuteScalar();
        }

        /// <summary>
        /// 用于不需要返回任何结果集的命令，如 INSERT、UPDATE、DELETE 等
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExNonQuery(string sql)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            return c.ExecuteNonQuery();
        }

        /// <summary>
        /// 用于不需要返回任何结果集的命令，如 INSERT、UPDATE、DELETE 等
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static int ExNonQuery(string sql, params SqlParameter[] para)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            c.Parameters.AddRange(para);
            return c.ExecuteNonQuery();
        }

        /// <summary>
        /// 用于需要返回结果集的命令，如 SELECT 等
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            return c.ExecuteReader();
        }

        /// <summary>
        /// 用于需要返回结果集的命令，如 SELECT 等
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] para)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            if (para != null)
                c.Parameters.AddRange(para);
            return c.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
