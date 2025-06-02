using BookDAL;
using BookModels;
using BookModels.Errors;
using System;
using System.Data.SqlClient;

namespace BookBLL {

    public class StuInfoManager {

        /// <summary>
        /// 插入学生信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static OperationResult<int, ErrorCode> InsertStuInfo(UserTable user) {
            if (string.IsNullOrEmpty(user.UserName) ||
             string.IsNullOrEmpty(user.StudentId) ||
             string.IsNullOrEmpty(user.Phone) ||
             string.IsNullOrEmpty(user.ClassName)) {
                return OperationResult<int, ErrorCode>.Fail(ErrorCode._error, "用户名、学号、电话、班级不能为空");
            }
            try {
                return 1 == StuInfService.InsertStuInfo(user) ?
                    OperationResult<int, ErrorCode>.Ok() :
                    OperationResult<int, ErrorCode>.Fail(ErrorCode._error);
            }
            catch (SqlException ex) {
                if (ErrorMessages.IsConflictError(ex))   // 判断是否唯一约束冲突
                    return OperationResult<int, ErrorCode>.Fail(ErrorCode._error, ex.Message); //该卡号已存在

                return OperationResult<int, ErrorCode>.Fail(ErrorCode._error, ex.Message); //其他错误
            }
            catch (Exception ex) {
                return OperationResult<int, ErrorCode>.Fail(ErrorCode._error, ex.Message); //其他错误
            }
        }

        /// <summary>
        /// 根据卡号查询学生信息
        /// </summary>
        /// <param name="cardNum"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static OperationResult<UserTable, ErrorCode> GetStuInfo(string cardNum) {
            try {
                using (SqlDataReader r = StuInfService.GetStuInfo(cardNum)) {
                    if (!r.Read())
                        return OperationResult<UserTable, ErrorCode>.Fail(ErrorCode._error, "该卡号不存在");

                    return OperationResult<UserTable, ErrorCode>.Ok(
                        new UserTable {
                            CardNum = r["CardNum"].ToString(),
                            UserName = r["UserName"].ToString(),
                            StudentId = r["StudentID"].ToString(),
                            Phone = r["Phone"].ToString(),
                            ClassName = r["Class"].ToString(),
                            Photo = r["Photo"].ToString(),
                            StartTime = Convert.ToDateTime(r["Start_Time"]),
                            EndTime = Convert.ToDateTime(r["Ending_Time"])
                        });
                }
            }
            catch (Exception ex) {
                return OperationResult<UserTable, ErrorCode>.Fail(ErrorCode._error, ex.Message);
            }
        }
    }
}