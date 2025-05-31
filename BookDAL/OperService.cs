using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDAL
{
    public class OperService
    {
        // TODO: 借书
        public static int BorrowBook(string userId, string bookId, string borrowAdminId, DateTime borrowDate)
        {
            string sql = $"";
            SqlParameter[] parameters = new SqlParameter[]
               {
               };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        // TODO:续借操作
        public static int RenewBook(string userId, string bookId, string renewAdminId, DateTime renewDate)
        {
            string sql = $"";
            SqlParameter[] parameters = new SqlParameter[]
               {
               };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        // TODO: 还书
        public static int ReturnBook(string userId, string bookId, string returnAdminId, DateTime returnDate)
        {
            string sql = $"";
            SqlParameter[] parameters = new SqlParameter[]
               {
               };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        // TODO: 查询借书记录
        public static SqlDataReader QueryBorrowRecord(string userId)
        {
            string sql = $"";
            SqlParameter[] parameters = new SqlParameter[]
               {
               };
            return DBHelper.ExecuteReader(sql, parameters);
        }

    }
}
