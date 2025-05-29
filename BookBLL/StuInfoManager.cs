using BookDAL;
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
        public static int InsertStuInfo(string cardNum, string userName, string studentId, string phone, string className, string photo, DateTime startTime, DateTime endTime)
        {
            try
            {
                return StuInfService.InsertStuInfo(cardNum, userName, studentId, phone, className, photo, startTime, endTime);
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
