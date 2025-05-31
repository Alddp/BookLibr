using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookDAL
{
    public class StuInfService
    {
        // 发卡, 插入学生信息到数据库
        public static int InsertStuInfo(string cardNum, string userName, string studentId, string phone, string className, string photo, DateTime startTime, DateTime endTime)
        {
            string sql = $"INSERT INTO [{UserTableFields.TableName}] (" +
                $"[{UserTableFields.CardNum}], " +
                $"[{UserTableFields.UserName}], " +
                $"[{UserTableFields.StudentID}], " +
                $"[{UserTableFields.Phone}], " +
                $"[{UserTableFields.Class}], " +
                $"[{UserTableFields.Photo}], " +
                $"[{UserTableFields.Start_Time}], " +
                $"[{UserTableFields.Ending_Time}]) " +
                $"VALUES (@cardNum, @userName, @studentId, @phone, @className, @photo, @startTime, @endTime)";

            SqlParameter[] parameters = new SqlParameter[]
           {
                new SqlParameter("@cardNum", cardNum),
                new SqlParameter("@userName", userName),
                new SqlParameter("@studentId", studentId),
                new SqlParameter("@phone", phone),
                new SqlParameter("@className", className),
                new SqlParameter("@photo", photo),
                new SqlParameter("@startTime", startTime),
                new SqlParameter("@endTime", endTime)
           };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        /// <summary>
        /// 读卡后获取学生信息
        /// </summary>
        /// <param name="cardNum">卡号</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader GetStuInfo(string cardNum)
        {
            string sql = $"SELECT * FROM [{UserTableFields.TableName}] WHERE [{UserTableFields.CardNum}] = @cardNum";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@cardNum", cardNum),
            };
            return DBHelper.ExecuteReader(sql, parameters);
        }
    }
}
