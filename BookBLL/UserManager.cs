using BookDAL;
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
        public static int CountByNamePwd(string name, string pwd)
        {
            try
            {
                return UserService.CountByNamePwd(name, pwd);
            }
            catch (SqlException ex)
            {
                return -1; // 数据库异常
            }
        }

        public static int CountUserNum()
        {
            return UserService.CountUserNum();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="usertype"></param>
        /// <param name="phone"></param>
        /// <returns>
        /// 1 成功
        /// -1 其他异常 
        /// -2 唯一约束冲突
        /// </returns>
        public static int UsersInsert(string name, string pwd, string usertype, string phone)
        {
            // 参数校验
            // 用户名密码类型和电话不能为空或空字符串
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(usertype) || string.IsNullOrEmpty(phone))
            {
                return -3; // 参数不能为空
            }
            try
            {
                return UserService.UsersInsert(name, pwd, usertype, phone);
            }
            catch (SqlException ex)
            {
                // 判断是否唯一约束冲突
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    // 2627/2601 是唯一约束冲突的错误号
                    // 可以返回特定错误码，或抛出自定义异常
                    return -2;
                }
                // 其他数据库异常
                return -1;
            }
            catch (Exception ex)
            {
                // 处理其他异常
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
