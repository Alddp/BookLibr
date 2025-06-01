using BookDAL;
using BookModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBLL
{
    public class UserManager
    {
        public static int CountByNamePwd(string name, string pwd, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                return UserService.CountByNamePwd(name, pwd);
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
                return -1;
            }
        }

        public static int CountUserNum()
        {
            return UserService.CountUserNum();
        }


        public static int UsersInsert(Admin admin, out string errorMessage)
        {
            errorMessage = string.Empty;
            // 参数校验 用户名密码类型和电话不能为空或空字符串
            if (string.IsNullOrEmpty(admin.Username) || string.IsNullOrEmpty(admin.Pwd) || string.IsNullOrEmpty(admin.Type) || string.IsNullOrEmpty(admin.Phone))
            {
                errorMessage = "参数不能为空";
                return -3;
            }
            try
            {
                return UserService.UsersInsert(admin);
            }
            catch (SqlException ex)
            {
                // 判断是否唯一约束冲突
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    errorMessage = "用户名已存在";
                    return -2;
                }
                errorMessage = "数据库异常";
                return -1;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return -1;
            }
        }
    }
}
