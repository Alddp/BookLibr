using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModels.Errors
{
    public enum UserErrorCode
    {
        None,
        UserNotFound,
        InvalidCard,
        LoginFailed,
        ExpiredAccount
    }

    public enum BookErrorCode
    {
        None,
        BookNotFound,
        OutOfStock,
        InvalidISBN,
        AlreadyBorrowed
    }

    public enum BorrowErrorCode
    {
        None,
        BookUnavailable,
        UserNotAllowed,
        ExceededLimit,
        BorrowFailed
    }
}
