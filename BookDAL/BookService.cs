using BookModels;
using BookModels.Constants;
using System.Data.SqlClient;

namespace BookDAL {

    public class BookService {

        /// <summary>
        /// 新增图书信息（书名、作者、ISBN、封面等）
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static int BookInsert(Book book) {
            string tableName = BookTableFields.TableName;
            string bookNameColumn = BookTableFields.BookName;
            string authorColumn = BookTableFields.Author;
            string ISBNColumn = BookTableFields.ISBN;
            string pictureColumn = BookTableFields.Picture;
            string priceColumn = BookTableFields.Price;
            string shelfIdColumn = BookTableFields.ShelfId;

            string sql = $@"INSERT INTO {tableName}
           ({bookNameColumn}, {authorColumn}, {ISBNColumn},
            {pictureColumn}, {priceColumn}, {shelfIdColumn})
           VALUES (@BookName, @Author, @ISBN, @Picture, @Price, @ShelfId)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookName", book.BookName),
                new SqlParameter("@Author", book.Author),
                new SqlParameter("@ISBN", book.ISBN),
                new SqlParameter("@Picture", book.Picture),
                new SqlParameter("@Price", book.Price),
                new SqlParameter("@ShelfId", book.ShelfId)
            };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        /// <summary>
        /// 用于统计图书表数量
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static int CountBookNum(string bookId) {
            string tableName = BookTableFields.TableName;
            string bookIdColumn = BookTableFields.BookId;

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
        public static SqlDataReader SearchBook(string info) {
            string sql = $@" SELECT *
                FROM {BookTableFields.TableName}
                WHERE {BookTableFields.BookName} LIKE @Keyword
                OR {BookTableFields.Author} LIKE @Keyword
                OR {BookTableFields.ISBN} LIKE @Keyword";

            SqlParameter[] parameters = {
                new SqlParameter("@Keyword", $"%{info}%")
            };

            return DBHelper.ExecuteReader(sql, parameters);
        }

        //修改库存数量
        /// <summary>
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public static int UpdateInventory(string bookId, int inventory) {
            string tableName = BookTableFields.TableName;
            string bookIdColumn = BookTableFields.BookId;
            string inventoryColumn = BookTableFields.Inventory;

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