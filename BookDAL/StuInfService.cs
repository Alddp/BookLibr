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
            string sql = $"INSERT INTO [{TabManager.UserTable.tableName}] (" +
                $"[{TabManager.UserTable.CardNum}], " +
                $"[{TabManager.UserTable.UserName}], " +
                $"[{TabManager.UserTable.StudentID}], " +
                $"[{TabManager.UserTable.Phone}], " +
                $"[{TabManager.UserTable.Class}], " +
                $"[{TabManager.UserTable.Photo}], " +
                $"[{TabManager.UserTable.Start_Time}], " +
                $"[{TabManager.UserTable.Ending_Time}]) " +
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


    }
}
