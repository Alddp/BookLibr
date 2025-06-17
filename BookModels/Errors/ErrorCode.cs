using System.Collections.Generic;
using System.Data.SqlClient;

namespace BookModels.Errors {

    public enum ErrorCode {

        // 通用
        None = 0,                    // 操作成功，无错误

        UnknownError,                // 系统发生未知错误
        InvalidParameter,            // 参数格式无效
        DatabaseError,               // 数据库操作异常
        DuplicateKey,                // 数据重复违反唯一约束
        NotFound,                    // 未找到相关数据
        Unauthorized,                // 用户未授权
        Forbidden,                   // 禁止访问此资源
        Timeout,                     // 操作超时，请重试
        OperationFailed,             // 操作执行失败
        ForeignKeyViolation,         // 外键约束违反

        // 用户相关（User）
        UserNotFound,                // 用户不存在

        InvalidCard,                 // 卡号无效
        LoginFailed,                 // 账号或密码错误
        ExpiredAccount,              // 账户已过期
        UserAlreadyExists,           // 用户已存在
        UserCreationFailed,          // 用户创建失败

        // 图书相关（Book）
        BookNotFound,                // 图书不存在

        InvalidISBN,                 // ISBN格式无效
        OutOfStock,                  // 图书库存不足
        AlreadyBorrowed,             // 用户已借阅该图书
        BookAlreadyExists,           // 图书已存在
        BookInsertFailed,            // 图书插入失败

        // 借阅相关（Borrow）
        BookUnavailable,             // 图书不可用

        UserNotAllowedToBorrow,      // 用户无借阅权限
        ExceededBorrowLimit,         // 超出借阅数量限制
        BorrowFailed,                // 借阅操作失败
        BorrowRecordNotFound,        // 借阅记录不存在
        ReturnFailed,                // 还书操作失败

        // 还书/续借相关（Return / Renew）
        RenewFailed,                 // 续借操作失败

        AlreadyReturned,             // 图书已归还
        ReturnRecordNotFound,        // 归还记录不存在

        // 管理员 / 权限
        AdminNotFound,               // 管理员不存在

        PermissionDenied,            // 权限不足
        RoleAssignmentFailed,        // 角色分配失败

        // 网络 / 系统
        NetworkError,                // 网络连接错误

        ServerUnavailable,           // 服务器不可用
        ServiceUnavailable,          // 服务不可用
        ConfigurationError           // 配置错误
    }

    public static class ErrorMessages {

        private static readonly Dictionary<ErrorCode, string> _messages = new Dictionary<ErrorCode, string>(){
            // 通用错误
            { ErrorCode.None, "操作成功" },
            { ErrorCode.UnknownError, "系统发生未知错误" },
            { ErrorCode.InvalidParameter, "参数格式无效" },
            { ErrorCode.DatabaseError, "数据库操作异常" },
            { ErrorCode.DuplicateKey, "数据重复违反唯一约束" },
            { ErrorCode.NotFound, "未找到相关数据" },
            { ErrorCode.Unauthorized, "用户未授权" },
            { ErrorCode.Forbidden, "禁止访问此资源" },
            { ErrorCode.Timeout, "操作超时，请重试" },
            { ErrorCode.OperationFailed, "操作执行失败" },

            // 用户相关
            { ErrorCode.UserNotFound, "用户不存在" },
            { ErrorCode.InvalidCard, "卡号无效" },
            { ErrorCode.LoginFailed, "账号或密码错误" },
            { ErrorCode.ExpiredAccount, "账户已过期" },
            { ErrorCode.UserAlreadyExists, "用户已存在" },
            { ErrorCode.UserCreationFailed, "用户创建失败" },

            // 图书相关
            { ErrorCode.BookNotFound, "图书不存在" },
            { ErrorCode.InvalidISBN, "ISBN格式无效" },
            { ErrorCode.OutOfStock, "图书库存不足" },
            { ErrorCode.AlreadyBorrowed, "用户已借阅该图书" },
            { ErrorCode.BookAlreadyExists, "图书已存在" },
            { ErrorCode.BookInsertFailed, "图书插入失败" },

            // 借阅相关
            { ErrorCode.BookUnavailable, "图书不可用" },
            { ErrorCode.UserNotAllowedToBorrow, "用户无借阅权限" },
            { ErrorCode.ExceededBorrowLimit, "超出借阅数量限制" },
            { ErrorCode.BorrowFailed, "借阅操作失败" },
            { ErrorCode.BorrowRecordNotFound, "借阅记录不存在" },
            { ErrorCode.ReturnFailed, "还书操作失败" },

            // 还书/续借
            { ErrorCode.RenewFailed, "续借操作失败" },
            { ErrorCode.AlreadyReturned, "图书已归还" },
            { ErrorCode.ReturnRecordNotFound, "归还记录不存在" },

            // 管理员/权限
            { ErrorCode.AdminNotFound, "管理员不存在" },
            { ErrorCode.PermissionDenied, "权限不足" },
            { ErrorCode.RoleAssignmentFailed, "角色分配失败" },

            // 系统/网络
            { ErrorCode.NetworkError, "网络连接异常" },
            { ErrorCode.ServerUnavailable, "服务器不可用" },
            { ErrorCode.ServiceUnavailable, "服务不可用" },
            { ErrorCode.ConfigurationError, "系统配置错误" }
        };

        /// <summary>
        /// 数据库唯一约束冲突错误
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static bool IsConflictError(SqlException ex) {
            return ex.Number == 2627 || ex.Number == 2601;
        }

        public static string GetMessage(ErrorCode code, string errorMessage = default) {
            // 判断errorMessage是否为null
            var res = _messages.TryGetValue(code, out var msg);

            msg = errorMessage != default
                ? msg + ":\n" + errorMessage
                : msg;

            return res
                ? msg
                : "未定义的错误";
        }
    }
}