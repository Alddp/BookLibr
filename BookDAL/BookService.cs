﻿using BookModels;
using BookModels.Constants;
using System;
using System.Data.SqlClient;

namespace BookDAL {

    public class BookService {

        // 新增图书信息（书名、作者、ISBN、封面等）
        public static int BookInsert(Book book) {
            string tableName = BookTableFields.TableName;
            string bookNameColumn = BookTableFields.BookName;
            string authorColumn = BookTableFields.Author;
            string ISBNColumn = BookTableFields.ISBN;
            string pictureColumn = BookTableFields.Picture;
            string priceColumn = BookTableFields.Price;
            string shelfIdColumn = BookTableFields.SlotId;

            string sql = $@"INSERT INTO {tableName}
           ({bookNameColumn}, {authorColumn}, {ISBNColumn},
            {pictureColumn}, {priceColumn}, {shelfIdColumn})
           VALUES (@BookName, @Author, @ISBN, @Picture, @Price, @SlotId)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookName", book.BookName),
                new SqlParameter("@Author", book.Author),
                new SqlParameter("@ISBN", book.ISBN),
                new SqlParameter("@Picture", book.Picture),
                new SqlParameter("@Price", book.Price),
                new SqlParameter("@SlotId", book.SlotId)
            };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        // 用于统计图书表数量
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

        // 模糊查询（书名、作者、ISBN）
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

        // 指定图书库存变化stockChange
        public static int UpdateBookStock(string bookId, int stockChange) {
            string tableName = BookTableFields.TableName;
            string bookIdColumn = BookTableFields.BookId;
            string inventoryColumn = BookTableFields.Inventory;

            string sql = $@"UPDATE {tableName} SET {inventoryColumn} = {inventoryColumn} + @StockChange WHERE {bookIdColumn} = @BookId";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@BookId", bookId),
                new SqlParameter("@StockChange", stockChange),
            };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        // 借书,添加操作员ID和借书时间
        public static int BorrowReaderBorroredBook(string userId, string bookId, string borrowOperId, DateTime borrowDate) {
            string tableName = BorrowTableFields.TableName;
            string userIdColumn = BorrowTableFields.UserId;
            string bookIdColumn = BorrowTableFields.BookId;
            string borrowAdminIdColumn = BorrowTableFields.BorrowAdminId;
            string borrowDateColumn = BorrowTableFields.BorrowDate;

            string sql = $@"INSERT INTO {tableName}
                        ({userIdColumn}, {bookIdColumn}, {borrowAdminIdColumn}, {borrowDateColumn})
                        VALUES (@UserId, @BookId, @BorrowAdminId, @BorrowDate)";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@BookId", bookId),
                new SqlParameter("@BorrowAdminId", borrowOperId),
                new SqlParameter("@BorrowDate", borrowDate),
            };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        // 还书,添加操作员ID和还书时间
        public static int ReturnReaderBorroredBook(string userId, string bookId, string returnOperId, DateTime returnDate) {
            string tableName = BorrowTableFields.TableName;
            string userIdColumn = BorrowTableFields.UserId;
            string bookIdColumn = BorrowTableFields.BookId;
            string returnAdminIdColumn = BorrowTableFields.ReturnAdminId;
            string returnDateColumn = BorrowTableFields.ReturnDate;

            string sql = $@"Update {tableName}
                        SET {returnAdminIdColumn} = @ReturnAdminId ,{returnDateColumn} = @ReturnDate
                        WHERE {userIdColumn} = @UserId AND {bookIdColumn} = @BookId";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ReturnAdminId", returnOperId),
                new SqlParameter("@ReturnDate", returnDate),
                new SqlParameter("@UserId", userId),
                new SqlParameter("@BookId", bookId),
            };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        /// <summary>
        /// 查询图书借阅占比, 排行
        /// </summary>
        /// <returns>reader[bookIdFiledId] reader[bookNameFieldId] reader["BorrowCount"]</returns>
        public static SqlDataReader SearchHotBook() {
            string bookTable = BookTableFields.TableName;
            string borrowTable = BorrowTableFields.TableName;

            string sql = $@"SELECT TOP 30 b.{BookTableFields.BookId} AS BookId, b.{BookTableFields.BookName} AS BookName,
                    COUNT(br.{BorrowTableFields.BookId}) AS BorrowCount,
                    FORMAT(COUNT(*) * 1.0 / total.total_count, 'P2') AS BorrowPercentage
                FROM {bookTable} b
                LEFT JOIN {borrowTable} br ON b.{BookTableFields.BookId} = br.{BorrowTableFields.BookId}
                CROSS JOIN (SELECT COUNT(*) AS total_count FROM {borrowTable}) AS total
                GROUP BY b.{BookTableFields.BookId}, b.{BookTableFields.BookName}, total.total_count
                ORDER BY BorrowCount DESC";

            return DBHelper.ExecuteReader(sql);
        }
    }
}