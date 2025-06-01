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
    public class StuInfoManager
    {
        /// <summary>
        /// 插入学生信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static int InsertStuInfo(UserTable user, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                return StuInfService.InsertStuInfo(user);
            }
            catch (SqlException ex)
            {
                // 判断是否唯一约束冲突
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    // 2627/2601 是唯一约束冲突的错误号
                    errorMessage = "该卡号已存在";
                    return -2;
                }
                // 其他数据库异常
                errorMessage = "数据库异常：" + ex.Message;
                return -1;
            }
            catch (Exception ex)
            {
                // 处理其他异常
                errorMessage = "其他异常：" + ex.Message;
                return -1;
            }
        }


        /// <summary>
        /// 根据卡号查询学生信息
        /// </summary>
        /// <param name="cardNum"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static UserTable GetStuInfo(string cardNum, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                SqlDataReader r = StuInfService.GetStuInfo(cardNum);
                if (!r.Read())
                {
                    errorMessage = "未找到该卡号";
                    return null;
                }

                return new UserTable
                {
                    CardNum = r["CardNum"].ToString(),
                    UserName = r["UserName"].ToString(),
                    StudentId = r["StudentID"].ToString(),
                    Phone = r["Phone"].ToString(),
                    ClassName = r["Class"].ToString(),
                    Photo = r["Photo"].ToString(),
                    StartTime = Convert.ToDateTime(r["Start_Time"]),
                    EndTime = Convert.ToDateTime(r["Ending_Time"])
                };
            }
            catch (Exception ex)
            {
                errorMessage = "数据库异常：" + ex.Message;
                return null;
            }
        }
    }
}
