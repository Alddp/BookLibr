using BookDAL;
using BookModels;
using BookModels.Errors;
using System;
using System.Data.SqlClient;

namespace BookBLL {

    public class UserManager {

        // TODO: 将返回类型改为Admin
        public static OperationResult<int, ErrorCode> Login(string name, string pwd) {
            if (string.IsNullOrWhiteSpace(name))
                return OperationResult<int, ErrorCode>.Fail(ErrorCode.Login_Failed, "用户名为空");

            try {
                int res = UserService.CountByNamePwd(name, pwd);

                return res > 0 ?
                    OperationResult<int, ErrorCode>.Ok(res) :
                    OperationResult<int, ErrorCode>.Fail(ErrorCode.Login_Failed, ErrorMessages.GetMessage(ErrorCode.Login_Failed));
            }
            catch (SqlException ex) {
                return OperationResult<int, ErrorCode>.Fail(ErrorCode.DatabaseError, "数据库异常：" + ex.Message);
            }
            catch (Exception ex) {
                return OperationResult<int, ErrorCode>.Fail(ErrorCode._error, "未知异常：" + ex.Message);
            }
        }

        public static OperationResult<int, ErrorCode> CountUserNum() {
            try {
                int res = UserService.CountUserNum();
                return res > 0 ?
                    OperationResult<int, ErrorCode>.Ok(res) :
                    OperationResult<int, ErrorCode>.Fail(ErrorCode._error, ErrorMessages.GetMessage(ErrorCode._error));
            }
            catch (SqlException ex) {
                return OperationResult<int, ErrorCode>.Fail(ErrorCode.DatabaseError, "数据库异常：" + ex.Message);
            }
            catch (Exception ex) {
                return OperationResult<int, ErrorCode>.Fail(ErrorCode._error, "未知异常：" + ex.Message);
            }
        }

        public static OperationResult<int, ErrorCode> UsersInsert(Admin admin) {
            // 参数校验 用户名密码类型和电话不能为空或空字符串
            if (string.IsNullOrEmpty(admin.Username) || string.IsNullOrEmpty(admin.Pwd) || string.IsNullOrEmpty(admin.Type) || string.IsNullOrEmpty(admin.Phone)) {
                return OperationResult<int, ErrorCode>.Fail(ErrorCode._error, "用户名密码类型和电话不能为空或空字符串");
            }
            try {
                int res = UserService.UsersInsert(admin);
                return res > 0 ?
                    OperationResult<int, ErrorCode>.Ok(res) :
                    OperationResult<int, ErrorCode>.Fail(ErrorCode._error, ErrorMessages.GetMessage(ErrorCode._error));
            }
            catch (SqlException ex) {
                // 判断是否唯一约束冲突
                if (ErrorMessages.IsConflictError(ex)) {
                    return OperationResult<int, ErrorCode>.Fail(ErrorCode._error, "用户名已存在");
                }

                return OperationResult<int, ErrorCode>.Fail(ErrorCode._error, ex.Message);
            }
            catch (Exception ex) {
                return OperationResult<int, ErrorCode>.Fail(ErrorCode._error, ex.Message);
            }
        }
    }
}