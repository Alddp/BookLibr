using BookBLL.Utils;
using BookDAL;
using BookModels;
using BookModels.Errors;
using System;
using System.Data.SqlClient;

namespace BookBLL {

    public class ReaderManager {

        // 插入学生信息
        public static OperationResult<int> InsertStuInfo(Reader user) {
            // 参数校验
            if (string.IsNullOrWhiteSpace(user.UserName) ||
                string.IsNullOrWhiteSpace(user.StudentId) ||
                string.IsNullOrWhiteSpace(user.Phone) ||
                string.IsNullOrWhiteSpace(user.ClassName)) {
                return OperationResult<int>.Fail(ErrorCode.InvalidParameter);
            }

            var res = ResultWrapper.Wrap(() => ReaderService.InsertStuInfo(user));

            return res.Success
                ? res
                : OperationResult<int>.Fail(ErrorCode.UserAlreadyExists);
        }

        // 根据卡号查询学生信息
        public static OperationResult<Reader> GetStuInfo(string cardNum) {
            var result = ResultWrapper.Wrap(() => {
                using (SqlDataReader r = ReaderService.GetStuInfo(cardNum)) {
                    if (!r.Read())
                        return default;

                    return new Reader {
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
            });

            return result.Data != default
                ? result
                : OperationResult<Reader>.Fail(ErrorCode.InvalidCard);
        }
    }
}