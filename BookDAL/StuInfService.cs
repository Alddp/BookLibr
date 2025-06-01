using BookModels;
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
        public static int InsertStuInfo(UserTable user)
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
                new SqlParameter("@cardNum", user.CardNum),
                new SqlParameter("@userName", user.UserName),
                new SqlParameter("@studentId", user.StudentId),
                new SqlParameter("@phone", user.Phone),
                new SqlParameter("@className", user.ClassName),
                new SqlParameter("@photo", user.Photo),
                new SqlParameter("@startTime", user.StartTime),
                new SqlParameter("@endTime", user.EndTime)
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
