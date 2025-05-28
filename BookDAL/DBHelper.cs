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
                string constring = "Data Source=.\\SQLEXPRESS; Initial Catalog=Parking; Integrated Security=true";

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

        //改写ExecuteScalar方法 用于多次调用
        public static int ExScalar(string sql)
        {

            SqlCommand c = new SqlCommand();
            c.CommandText = sql;
            c.Connection = DBHelper.Connection;
            int i = (int)c.ExecuteScalar();
            return i;
        }

        //改写ExecuteNonQuery方法 用于多次调用 增 删 改

        public static int ExNonQuery(string sql)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            return c.ExecuteNonQuery();
        }
        public static int ExNonQuery(string sql, params SqlParameter[] para)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            c.Parameters.AddRange(para);
            return c.ExecuteNonQuery();
        }

        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlCommand c = new SqlCommand(sql, Connection);
            return c.ExecuteReader();
        }
    }
}
