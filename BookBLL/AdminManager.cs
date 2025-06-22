using BookBLL.Utils;
using BookDAL;
using BookModels;
using BookModels.Constants;
using BookModels.Errors;
using System.Collections.Generic;
using System.Data.SqlClient;
using static BookModels.Errors.ErrorMessages;

namespace BookBLL {

    public class AdminManager {

        public static OperationResult<Admin> Login(string name, string pwd) {
            if (string.IsNullOrWhiteSpace(name))
                return OperationResult<Admin>.Fail(
                    ErrorCode.InvalidParameter,
                    GetMessage(ErrorCode.InvalidParameter, "用户名不能为空"));

            var countRes = ResultWrapper.Wrap(() => AdminService.CountByNamePwd(name, pwd));

            if (!countRes.Success || countRes.Data <= 0) return OperationResult<Admin>.Fail(ErrorCode.LoginFailed);

            var res = ResultWrapper.Wrap(() => {
                using (SqlDataReader r = AdminService.GetLoginUser(name, pwd)) {
                    if (!r.Read())
                        return default;

                    Admin.Instance.AdminId = r[AdminTableFields.AdminId].ToString();
                    Admin.Instance.UserName = r[AdminTableFields.Username].ToString();
                    Admin.Instance.Phone = r[AdminTableFields.Phone].ToString();
                    Admin.Instance.Type = r[AdminTableFields.Type].ToString();

                    return Admin.Instance;
                }
            });
            return res;
        }

        public static OperationResult<int> CountUserNum() {
            return ResultWrapper.Wrap(() => AdminService.CountUserNum());
        }

        public static OperationResult<int> UsersInsert(Admin admin) {
            // 参数校验 用户名密码类型和电话不能为空或空字符串
            if (string.IsNullOrEmpty(admin.UserName) || string.IsNullOrEmpty(admin.Pwd) || string.IsNullOrEmpty(admin.Type) || string.IsNullOrEmpty(admin.Phone)) {
                return OperationResult<int>.Fail(
                    ErrorCode.InvalidParameter,
                    GetMessage(ErrorCode.InvalidParameter, "用户名密码类型和电话不能为空或空字符串"));
            }
            var res = ResultWrapper.Wrap(() => AdminService.UsersInsert(admin));

            return res.Success
                ? res
                : OperationResult<int>.Fail(ErrorCode.UserAlreadyExists);
        }

        public static OperationResult<List<Admin>> GetAllAdmins() {
            return ResultWrapper.Wrap(() => {
                var admins = new List<Admin>();
                using (var reader = AdminService.GetAllAdmins()) {
                    while (reader.Read()) {
                        admins.Add(new Admin {
                            AdminId = reader[AdminTableFields.AdminId].ToString(),
                            UserName = reader[AdminTableFields.Username].ToString(),
                            Phone = reader[AdminTableFields.Phone].ToString(),
                            Type = reader[AdminTableFields.Type].ToString(),
                        });
                    }
                }
                return admins;
            });
        }

        public static OperationResult<int> DeleteAdminById(string adminId) {
            if (string.IsNullOrWhiteSpace(adminId)) {
                return OperationResult<int>.Fail(ErrorCode.InvalidParameter, "Admin ID cannot be empty.");
            }

            return ResultWrapper.Wrap(() => AdminService.DeleteAdminById(adminId));
        }
    }
}