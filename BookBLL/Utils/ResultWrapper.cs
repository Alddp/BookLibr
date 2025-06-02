using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookModels.Errors;
using System.Data.SqlClient;

namespace BookBLL.Utils {

    public static class ResultWrapper {

        /// <summary>
        /// 封装带返回值的操作（如查询、登录等）
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static OperationResult<TData, ErrorCode> Wrap<TData>(Func<TData> func) {
            try {
                TData result = func();
                return OperationResult<TData, ErrorCode>.Ok(result);
            }
            catch (SqlException ex) {
                if (ErrorMessages.IsConflictError(ex))
                    return OperationResult<TData, ErrorCode>.Fail(ErrorCode.DuplicateKey, "数据重复：" + ex.Message);
                return OperationResult<TData, ErrorCode>.Fail(ErrorCode.DatabaseError, "数据库异常：" + ex.Message);
            }
            catch (Exception ex) {
                return OperationResult<TData, ErrorCode>.Fail(ErrorCode._error, "未知异常：" + ex.Message);
            }
        }
    }
}