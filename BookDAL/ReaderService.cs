using BookModels;
using BookModels.Constants;
using System.Data.SqlClient;

namespace BookDAL {

    public class ReaderService {

        // 发卡, 插入学生信息到数据库
        public static int InsertStuInfo(Reader user) {
            string sql = $"INSERT INTO [{ReaderTableFields.TableName}] (" +
                $"[{ReaderTableFields.CardNum}], " +
                $"[{ReaderTableFields.UserName}], " +
                $"[{ReaderTableFields.StudentID}], " +
                $"[{ReaderTableFields.Phone}], " +
                $"[{ReaderTableFields.Class}], " +
                $"[{ReaderTableFields.Photo}], " +
                $"[{ReaderTableFields.Start_Time}], " +
                $"[{ReaderTableFields.Ending_Time}]) " +
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
        public static SqlDataReader GetStuInfo(string cardNum) {
            string sql = $"SELECT * FROM [{ReaderTableFields.TableName}] WHERE [{ReaderTableFields.CardNum}] = @cardNum";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@cardNum", cardNum),
            };
            return DBHelper.ExecuteReader(sql, parameters);
        }

        public static SqlDataReader GetAllReaders() {
            string sql = $"SELECT * FROM [{ReaderTableFields.TableName}]";
            return DBHelper.ExecuteReader(sql, null);
        }
    }
}