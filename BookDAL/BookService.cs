using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookDAL
{
    public class BookService
    {
        /// <summary>
        /// TODO:新增图书信息（书名、作者、ISBN、封面等）
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="author"></param>
        /// <param name="ISBN"></param>
        /// <param name="picture"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static int BookInsert(string bookName, string author, string ISBN, string picture, string price)
        {
            string sql = $"";
            SqlParameter[] parameters = new SqlParameter[]
               {
               };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        /// <summary>
        /// TODO:用于统计图书表数量
        /// </summary>
        /// <param name="bookId">图书编号</param>
        /// <returns></returns>
        public static int CountBookNum(string bookId)
        {
            string sql = $"";
            SqlParameter[] parameters = new SqlParameter[]
               {
               };
            return DBHelper.ExScalar(sql, parameters);
        }

        /// <summary>
        /// TODO:模糊查询（书名、作者、ISBN）
        /// </summary>
        /// <param name="info">关键字（书名、作者、ISBN）</param>
        /// <returns></returns>
        public static SqlDataReader SearchBook(string info)
        {
            string sql = $"";
            SqlParameter[] parameters = new SqlParameter[]
               {
               };
            return DBHelper.ExecuteReader(sql, parameters);
        }

        // TODO:修改库存数量
        public static int UpdateInventory(string bookId, int inventory)
        {
            string sql = $"";
            SqlParameter[] parameters = new SqlParameter[]
               {
               };
            return DBHelper.ExNonQuery(sql, parameters);
        }
    }
}
