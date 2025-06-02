using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModels.Errors {

    public enum ErrorCode {
        None,

        _error,
        DatabaseError,
        DuplicateKey,

        InvalidParameter,
        NoDataFound,

        Login_Failed,

        User_UserNotFound,
        User_InvalidCard,
        User_LoginFailed,
        User_ExpiredAccount,

        Book_BookNotFound,
        Book_OutOfStock,
        Book_InvalidISBN,
        Book_AlreadyBorrowed,

        Borrow_BookUnavailable,
        Borrow_UserNotAllowed,
        Borrow_ExceededLimit,
        Borrow_BorrowFailed,
        Borrow_NoDataFound
    }

    public static class ErrorMessages {

        /// <summary>
        /// 数据库唯一约束冲突错误
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static bool IsConflictError(SqlException ex) {
            return ex.Number == 2627 || ex.Number == 2601;
        }

        public static string GetMessage(ErrorCode code) {
            switch (code) {
                // 通用错误 ==============================================
                case ErrorCode.None:
                    return "No error";

                case ErrorCode.InvalidParameter:
                    return "无效参数";

                case ErrorCode.Login_Failed:
                    return "用户名或密码错误";
                // User ==============================================
                case ErrorCode.User_UserNotFound:
                    return "用户未找到";

                case ErrorCode.User_InvalidCard:
                    return "Invalid card";

                case ErrorCode.User_LoginFailed:
                    return "Login failed";

                case ErrorCode.User_ExpiredAccount:
                    return "Account expired";
                // Book
                case ErrorCode.Book_BookNotFound:
                    return "没有找到相关书籍";

                case ErrorCode.Book_OutOfStock:
                    return "";

                case ErrorCode.Book_InvalidISBN:
                    return "无效的ISBN";

                case ErrorCode.Book_AlreadyBorrowed:
                    return "Book already borrowed";
                // Borrow ==============================================
                case ErrorCode.Borrow_BookUnavailable:
                    return "Book unavailable";

                case ErrorCode.Borrow_UserNotAllowed:
                    return "User not allowed to borrow";

                case ErrorCode.Borrow_ExceededLimit:
                    return "Exceeded borrowing limit";

                case ErrorCode.Borrow_BorrowFailed:
                    return "Borrowing failed";

                case ErrorCode.Borrow_NoDataFound:
                    return "No borrow records found";
                // unknow ==============================================
                default:
                    return "Unknown error";
            }
        }
    }
}