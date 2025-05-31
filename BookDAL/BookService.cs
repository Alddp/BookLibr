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

using static BookDAL.TabManager;
namespace BookDAL
{
    public class BookService
    {
        /// <summary>
        /// 新增图书信息（书名、作者、ISBN、封面等）
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="author"></param>
        /// <param name="ISBN"></param>
        /// <param name="picture"></param>
        /// <param name="price"></param> 
        ///  <param name="shelfId"></param>
        /// <returns></returns>
        public static int BookInsert(string bookName, string author, string ISBN, string picture, string price, string shelfId)
        {
            string tableName = BookTable.tableName;
            string bookNameColumn = BookTable.BookName;
            string authorColumn = BookTable.Author;
            string ISBNColumn = BookTable.ISBN;
            string pictureColumn = BookTable.Picture;
            string priceColumn = BookTable.Price;
            string shelfIdColumn = BookTable.ShelfId;



            string sql = $@"INSERT INTO {tableName} 
           ({bookNameColumn}, {authorColumn}, {ISBNColumn}, 
            {pictureColumn}, {priceColumn}, {shelfIdColumn}) 
           VALUES (@BookName, @Author, @ISBN, @Picture, @Price, @ShelfId)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookName", bookName),
                new SqlParameter("@Author", author),
                new SqlParameter("@ISBN", ISBN),
                new SqlParameter("@Picture", picture),
                new SqlParameter("@Price", price),
                new SqlParameter("@ShelfId", shelfId)
            };
            return DBHelper.ExNonQuery(sql, parameters);
        }




        /// <summary>
        /// 用于统计图书表数量
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static int CountBookNum(string bookId)
        {
            string tableName = BookTable.tableName;
            string bookIdColumn = BookTable.BookId;   

            string sql = $"SELECT COUNT(*) FROM {tableName} WHERE {bookIdColumn} = @BookId";
            SqlParameter[] parameters = new SqlParameter[]
               {
                   new SqlParameter("@BookId", bookId)  // 添加参数
               };
            return DBHelper.ExScalar(sql, parameters);
        }

        /// <summary>
        /// 模糊查询（书名、作者、ISBN）
        /// </summary>
        /// <param name="info">关键字（书名、作者、ISBN）</param>
        /// <returns></returns>
        public static SqlDataReader SearchBook(string info)
        {
            string tableName = BookTable.tableName;
            string bookNameColumn = BookTable.BookName;
            string authorColumn = BookTable.Author;
            string ISBNColumn = BookTable.ISBN;

            string sql = $@" SELECT * 
              FROM {tableName} 
              WHERE {bookNameColumn} LIKE @Keyword 
              OR {authorColumn } LIKE @Keyword 
              OR {ISBNColumn} LIKE @Keyword";

            // 添加通配符实现模糊查询
            string keyword = $"%{info}%";


            SqlParameter[] parameters = new SqlParameter[]
               {
                   new SqlParameter("@Keyword", keyword)// 添加参数
               };
            return DBHelper.ExecuteReader(sql, parameters);
        }

        //修改库存数量
        /// <summary>
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public static int UpdateInventory(string bookId, int inventory)
        {
            string tableName = BookTable.tableName;
            string bookIdColumn = BookTable.BookId;
            string inventoryColumn = BookTable.Inventory;

            string sql = $@"UPDATE {tableName} SET {inventoryColumn} = @Inventory WHERE {bookIdColumn} = @BookId";
            SqlParameter[] parameters = new SqlParameter[]
               {
                   new SqlParameter("@BookId", bookId),
                   new SqlParameter("@Inventory", inventory)
               };
            return DBHelper.ExNonQuery(sql, parameters);
        }
    }
}
