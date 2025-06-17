using BookBLL.Utils;
using BookDAL;
using BookModels;
using BookModels.Constants;
using BookModels.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
                            BookId = reader[BookTableFields.BookId].ToString(),
                            BookName = reader[BookTableFields.BookName].ToString(),
                            Author = reader[BookTableFields.Author].ToString(),
                            ISBN = reader[BookTableFields.ISBN].ToString(),
                            Price = reader[BookTableFields.Price].ToString(),
                            Inventory = reader[BookTableFields.Inventory].ToString(),
                            Picture = reader[BookTableFields.Picture].ToString(),
                            ShelfId = (int)reader[BookTableFields.ShelfId]
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

        // 批量从Excel导入书籍
        public static OperationResult<int> ImportBooksFromExcel(string filePath) {
            var res = ResultWrapper.Wrap(() => {
                string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools", "library_tool.exe");
                string toolsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools");

                if (!File.Exists(exePath)) {
                    throw new Exception("未找到数据生成工具，请确保tools/library_tool.exe文件存在");
                }

                var startInfo = new System.Diagnostics.ProcessStartInfo {
                    FileName = "cmd.exe",
                    Arguments = $"/k {exePath} import --table book --excel {filePath} --db",
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    WorkingDirectory = toolsDir
                };

                using (var process = System.Diagnostics.Process.Start(startInfo)) {
                    process.WaitForExit();
                    return 0;
                }
            });
            return res;
        }
    }
}