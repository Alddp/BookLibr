using BookBLL.Utils;
using BookDAL;
using BookModels;
using BookModels.Constants;
using BookModels.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static BookModels.Errors.ErrorMessages;

namespace BookBLL {

    public class BookManager {

        // 借书操作
        public static OperationResult<int> BorrowBook(string readerId, string bookId, string operId) {
            var res = ResultWrapper.Wrap(() => {
                int row = BookService.BorrowReaderBorroredBook(readerId, bookId, operId, DateTime.Now);
                if (row != 1) return 0;
                row = BookService.UpdateBookStock(bookId, -1);
                if (row != 1) return 0;
                return row;
            });

            return res.Success
                ? OperationResult<int>.Ok()
                : OperationResult<int>.Fail(
                    ErrorCode.BorrowFailed,
                    GetMessage(ErrorCode.BorrowFailed, res.Message));
        }

        public static OperationResult<int> ReturnBook(string userId, string bookId, string operId) {
            var res = ResultWrapper.Wrap(() => {
                int row = BookService.ReturnReaderBorroredBook(userId, bookId, operId, DateTime.Now);
                if (row != 1) return 0;
                row = BookService.UpdateBookStock(bookId, 1);
                if (row != 1) return 0;
                return row;
            });

            return res.Success
                ? OperationResult<int>.Ok()
                : OperationResult<int>.Fail(
                    ErrorCode.ReturnFailed,
                    GetMessage(ErrorCode.ReturnFailed, res.Message));
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
                            BookId = reader["BookId"].ToString(),
                            BookName = reader["BookName"].ToString(),
                            Author = reader["Author"].ToString(),
                            ISBN = reader["ISBN"].ToString(),
                            Price = reader["Price"].ToString(),
                            Inventory = reader["Inventory"].ToString(),
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
                : OperationResult<int>.Fail(
                    ErrorCode.BookInsertFailed,
                    GetMessage(ErrorCode.BookInsertFailed, res.Message));
        }

        // 查询借阅记录
        public static OperationResult<BindingList<Borrow>> QueryBorrowRecord(string userId) {
            var res = ResultWrapper.Wrap(() => {
                var books = new BindingList<Borrow>();
                using (var reader = OperService.QueryBorrowRecord(userId)) {
                    while (reader.Read()) {
                        books.Add(new Borrow {
                            BorrowId = reader[BorrowTableFields.BorrowId].ToString(),
                            BookId = reader[BorrowTableFields.BookId].ToString(),
                            UserId = reader[BorrowTableFields.UserId].ToString(),
                            BorrowAdminId = reader[BorrowTableFields.BorrowAdminId].ToString(),
                            ReturnAdminId = reader[BorrowTableFields.ReturnAdminId].ToString(),
                            BorrowDate = reader[BorrowTableFields.BorrowDate] == DBNull.Value
                                ? (DateTime?)null
                                : (DateTime)reader[BorrowTableFields.BorrowDate],
                            ReturnDate = reader[BorrowTableFields.ReturnDate] == DBNull.Value
                                ? (DateTime?)null
                                : (DateTime)reader[BorrowTableFields.ReturnDate]
                        });
                    }
                }
                return books;
            });
            return res.Success
                ? res.Data.Count >= 0 ? res : OperationResult<BindingList<Borrow>>.Fail(ErrorCode.BorrowRecordNotFound)
                : res;
        }

        public static OperationResult<List<Book>> GetPopulerBooks() {
            var res = ResultWrapper.Wrap(() => {
                var books = new List<Book>();
                using (var reader = BookService.SearchHotBook()) {
                    string bookIdFiledId = BorrowTableFields.BookId;
                    string bookNameFieldId = BookTableFields.BookName;
                    string authorFieldId = BookTableFields.Author;
                    string ISBNFieldId = BookTableFields.ISBN;
                    while (reader.Read()) {
                        books.Add(new Book {
                            BookName = reader[bookNameFieldId].ToString(),
                            BookId = reader[bookIdFiledId].ToString(),
                            //Author = reader[authorFieldId].ToString(),
                            //ISBN = reader[ISBNFieldId].ToString(),
                            PopulerPercent = reader["BorrowPercentage"].ToString(),
                        });
                    }
                }
                return books;
            });
            return res;
        }
    }
}