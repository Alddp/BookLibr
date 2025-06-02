using BookBLL.Utils;
using BookDAL;
using BookModels;
using BookModels.Errors;
using static BookModels.Errors.ErrorMessages;

namespace BookBLL {

    public class UserManager {

        // TODO: 将返回类型改为Admin
        public static OperationResult<int> Login(string name, string pwd) {
            if (string.IsNullOrWhiteSpace(name))
                return OperationResult<int>.Fail(
                    ErrorCode.InvalidParameter,
                    GetMessage(ErrorCode.InvalidParameter, "用户名不能为空"));

            var res = ResultWrapper.Wrap(() => UserService.CountByNamePwd(name, pwd));

            return res.Success
                ? res.Data <= 0 ? OperationResult<int>.Fail(ErrorCode.LoginFailed, GetMessage(ErrorCode.LoginFailed)) : res
                : res;
        }

        public static OperationResult<int> CountUserNum() {
            return ResultWrapper.Wrap(() => UserService.CountUserNum());
        }

        public static OperationResult<int> UsersInsert(Admin admin) {
            // 参数校验 用户名密码类型和电话不能为空或空字符串
            if (string.IsNullOrEmpty(admin.Username) || string.IsNullOrEmpty(admin.Pwd) || string.IsNullOrEmpty(admin.Type) || string.IsNullOrEmpty(admin.Phone)) {
                return OperationResult<int>.Fail(
                    ErrorCode.InvalidParameter,
                    GetMessage(ErrorCode.InvalidParameter, "用户名密码类型和电话不能为空或空字符串"));
            }
            var res = ResultWrapper.Wrap(() => UserService.UsersInsert(admin));

            return res.Success
                ? res
                : OperationResult<int>.Fail(ErrorCode.UserAlreadyExists);
        }
    }
}