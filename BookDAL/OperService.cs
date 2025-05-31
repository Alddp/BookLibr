using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace BookDAL
{
    public class OperService
    {
        // 还书 书库数量增加1
        public static int IncreaseInventory(string bookId)
        {
            string tableName = BookTableFields.TableName;
            string bookINventoryColumn = BookTableFields.Inventory;
            string bookIdColumn = BookTableFields.BookId;
            string sql = $@" UPDATE {tableName} SET {bookINventoryColumn} = {bookIdColumn} + 1 WHERE {bookIdColumn} = @BookId";
            SqlParameter[] parameters = new SqlParameter[]
               {
                   new SqlParameter("@BookId", bookId)
               };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        // 借出书本 书库数量减少1
        public static int DecreaseInventory(string bookId)
        {
            string tableName = BookTableFields.TableName;
            string bookINventoryColumn = BookTableFields.Inventory;
            string bookIdColumn = BookTableFields.BookId;
            string sql = $@" UPDATE {tableName} SET {bookINventoryColumn} = {bookIdColumn} + 1 WHERE {bookIdColumn} = @BookId";
            SqlParameter[] parameters = new SqlParameter[]
               {
                   new SqlParameter("@BookId", bookId)
               };

            return DBHelper.ExNonQuery(sql, parameters);
        }

        //借书操作  添加到借书表
        public static int Borrowbook(string userId, string bookId, string borrowAdminId, DateTime borrowDate)
        {
            string tableName = BorrowTableFields.TableName;
            string userIdColumn = BorrowTableFields.UserId;
            string bookIdColumn = BorrowTableFields.BookId;
            string borrowAdminIdColumn = BorrowTableFields.BorrowAdminId;
            string borrowDateColumn = BorrowTableFields.BorrowDate;

            string sql = $@" INSERT INTO {tableName} ({userIdColumn}, {bookIdColumn}, {borrowAdminIdColumn}, {borrowDateColumn}
                         VALUES (@UserId, @BookId, @BorrowAdminId, @BorrowDate)";
            SqlParameter[] parameters = new SqlParameter[]
               {
                   new SqlParameter("@UserId", userId),
                   new SqlParameter("@BookId", bookId),
                   new SqlParameter("@BorrowAdminId", borrowAdminId),
                   new SqlParameter("@BorrowDate", borrowDate)
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

        //还书  添加到还书表
        public static int Returnbook(string userId, string bookId, string returnAdminId, DateTime returnDate)
        {
            string tableName = BorrowTableFields.TableName;
            string userIdColumn = BorrowTableFields.UserId;
            string bookIdColumn = BorrowTableFields.BookId;
            string returnAdminIdColumn = BorrowTableFields.ReturnAdminId;
            string returnDateColumn = BorrowTableFields.ReturnDate;
            string sql = $@"UPDATE {tableName} SET {returnAdminIdColumn} = @ReturnAdminId, {returnDateColumn} = @ReturnDate
                            WHERE {userIdColumn} = @UserId AND {bookIdColumn} = @BookId  AND {returnDateColumn} IS NULL";  // 只更新未归还的记录

            SqlParameter[] parameters = new SqlParameter[]
               {
                    new SqlParameter("@ReturnAdminId", returnAdminId),
                    new SqlParameter("@ReturnDate", returnDate),
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@BookId", bookId)
               };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        // 查询借书记录
        public static SqlDataReader QueryBorrowRecord(string userId)
        {
            string tableName = BorrowTableFields.TableName;
            string userIdColumn = BorrowTableFields.UserId;

            string sql = $@" SELECT * FROM {tableName} WHERE {userIdColumn} = @UserId";
            SqlParameter[] parameters = new SqlParameter[]
               {
                   new SqlParameter("@UserId", userId)
               };
            return DBHelper.ExecuteReader(sql, parameters);
        }
    }
}
