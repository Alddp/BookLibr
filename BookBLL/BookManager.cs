using BookDAL;
using BookModels;
using BookModels.Errors;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BookBLL {

    public class BookManager {

        // 借书操作
        public static OperationResult<int, ErrorCode> BorrowBook(string userId, string bookId) {
            //TODO: BookService.UpdateBookStock(bookId, -1);
            return OperationResult<int, ErrorCode>.Ok();
        }

        //TODO:
        public static OperationResult<int, ErrorCode> ReturnBook(string userId, string bookId) {
            return OperationResult<int, ErrorCode>.Ok();
        }

        //Complete: 优化返回的message
        //FixMe
        public static OperationResult<List<Book>, ErrorCode> SearchBook(string info) {
            if (string.IsNullOrWhiteSpace(info)) {
                return OperationResult<List<Book>, ErrorCode>.Fail(ErrorCode.InvalidParameter, "关键词不能为空");
            }

            try {
                var books = new List<Book>();
                using (var reader = BookService.SearchBook(info)) {
                    while (reader.Read()) {
                        books.Add(new Book {
                            BookId = (int)reader["BookId"],
                            BookName = reader["BookName"].ToString(),
                            Author = reader["Author"].ToString(),
                            ISBN = reader["ISBN"].ToString(),
                            Price = (decimal)reader["Price"],
                            Inventory = (int)reader["Inventory"],
                            Picture = reader["Picture"].ToString(),
                            ShelfId = (int)reader["ShelfId"]
                        });
                    }
                }

                if (books.Count == 0)
                    return OperationResult<List<Book>, ErrorCode>.Fail(ErrorCode.Book_BookNotFound, "未找到匹配图书");

                return OperationResult<List<Book>, ErrorCode>.Ok(books);
            }
            catch (SqlException ex) {
                return OperationResult<List<Book>, ErrorCode>.Fail(ErrorCode.InvalidParameter, "数据库错误：" + ex.Message);
            }
        }
    }
}