using BookModels.Errors;
using System;
using System.Data.SqlClient;

using static BookModels.Errors.ErrorMessages;

namespace BookBLL.Utils {

    public static class ResultWrapper {

        // 封装带返回值的操作（如查询、登录等）
        public static OperationResult<TData> Wrap<TData>(Func<TData> func) {
            try {
                TData result = func();
                return OperationResult<TData>.Ok(result);
            }
            catch (SqlException ex) {
                if (IsConflictError(ex))
                    return OperationResult<TData>.Fail(
                        ErrorCode.DuplicateKey,
                        GetMessage(ErrorCode.DuplicateKey, ex.Message));
                return OperationResult<TData>.Fail(
                    ErrorCode.DatabaseError,
                    GetMessage(ErrorCode.DatabaseError, ex.Message));
            }
            catch (Exception ex) {
                return OperationResult<TData>.Fail(
                    ErrorCode.UnknownError,
                    GetMessage(ErrorCode.UnknownError, ex.Message));
            }
        }
    }
}