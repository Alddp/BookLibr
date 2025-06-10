using BookBLL.Utils;
using BookDAL;
using BookModels;
using BookModels.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BookBLL {

    public class BookManager {

        // 借书操作
        public static OperationResult<int> BorrowBook(string readerId, string bookId, string operId) {
            return ResultWrapper.Wrap(() => {
                int row = BookService.BorrowReaderBorroredBook(readerId, bookId, operId, DateTime.Now);
                if (row != 1) return 0;
                row = BookService.UpdateBookStock(bookId, -1);
                if (row != 1) return 0;
                return row;
            });
        }

        public static OperationResult<int> ReturnBook(string userId, string bookId, string operId) {
            return ResultWrapper.Wrap(() => {
                int row = BookService.ReturnReaderBorroredBook(userId, bookId, operId, DateTime.Now);
                if (row != 1) return 0;
                row = BookService.UpdateBookStock(bookId, 1);
                if (row != 1) return 0;
                return row;
            });
        }

        public static OperationResult<List<Book>> SearchBook(string info) {
            if (string.IsNullOrWhiteSpace(info)) {
                return OperationResult<List<Book>>.Fail(ErrorCode.InvalidParameter, "关键词不能为空");
            }

            var res = ResultWrapper.Wrap(() => {
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
                return books;
            });

            return res.Success
                ? res.Data.Count >= 0 ? res : OperationResult<List<Book>>.Fail(ErrorCode.BookNotFound)
                : res;
        }

        public static OperationResult<int> InsertBook(Book book) {
            var res = ResultWrapper.Wrap(() => {
                return BookService.BookInsert(book);
            });
            return res.Success
                ? res
                : res;
        }

        // 查询借阅记录
        public static OperationResult<BindingList<Book>> QueryBorrowRecord(string userId) {
            return ResultWrapper.Wrap(() => {
                var books = new BindingList<Book>();
                using (var reader = OperService.QueryBorrowRecord(userId)) {
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
                return books;
            });
        }
    }
}