using BookDAL;
using BookModels;
using BookModels.Errors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBLL {

    public class UserManager {

        public static OperationResult<int, ErrorCode> Login(string name, string pwd) {
            if (string.IsNullOrWhiteSpace(name))
                return OperationResult<int, ErrorCode>.Fail(ErrorCode.Login_Failed, "用户名为空");

            int res = UserService.CountByNamePwd(name, pwd);

            return res > 0 ?
                OperationResult<int, ErrorCode>.Ok(res) :
                OperationResult<int, ErrorCode>.Fail(ErrorCode.Login_Failed, ErrorMessages.GetMessage(ErrorCode.Login_Failed));
        }

        public static OperationResult<int, ErrorCode> CountUserNum() {
            int res = UserService.CountUserNum();
            return res > 0 ?
                OperationResult<int, ErrorCode>.Ok(res) :
                OperationResult<int, ErrorCode>.Fail(ErrorCode._error, ErrorMessages.GetMessage(ErrorCode._error));
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