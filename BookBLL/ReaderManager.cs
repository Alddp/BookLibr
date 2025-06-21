using BookBLL.Utils;
using BookDAL;
using BookModels;
using BookModels.Constants;
using BookModels.Errors;
using System;
using System.Collections.Generic;
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
                        UserId = r[ReaderTableFields.UserId].ToString(),
                        CardNum = r[ReaderTableFields.CardNum].ToString(),
                        UserName = r[ReaderTableFields.UserName].ToString(),
                        StudentId = r[ReaderTableFields.StudentID].ToString(),
                        Phone = r[ReaderTableFields.Phone].ToString(),
                        ClassName = r[ReaderTableFields.Class].ToString(),
                        Photo = r[ReaderTableFields.Photo].ToString(),
                        StartTime = Convert.ToDateTime(r[ReaderTableFields.Start_Time]),
                        EndTime = Convert.ToDateTime(r[ReaderTableFields.Ending_Time]),
                        IsValid = Convert.ToBoolean(r[ReaderTableFields.Status])
                    };
                }
            });

            return result.Data != default
                ? result
                : OperationResult<Reader>.Fail(ErrorCode.InvalidCard);
        }

        // 销卡
        public static OperationResult<int> DestroyCard(string cardNum) {
            // 执行销卡操作
            var result = ResultWrapper.Wrap(() => OperService.DestroyCard(cardNum));

            return result.Success
                ? result
                : OperationResult<int>.Fail(ErrorCode.OperationFailed);
        }

        public static OperationResult<List<Reader>> GetAllReaders() {
            return ResultWrapper.Wrap(() => {
                var readers = new List<Reader>();
                using (var reader = ReaderService.GetAllReaders()) {
                    while (reader.Read()) {
                        readers.Add(new Reader {
                            UserId = reader[ReaderTableFields.UserId].ToString(),
                            CardNum = reader[ReaderTableFields.CardNum].ToString(),
                            UserName = reader[ReaderTableFields.UserName].ToString(),
                            StudentId = reader[ReaderTableFields.StudentID].ToString(),
                            Phone = reader[ReaderTableFields.Phone].ToString(),
                            ClassName = reader[ReaderTableFields.Class].ToString(),
                            Photo = reader[ReaderTableFields.Photo].ToString(),
                            StartTime = Convert.ToDateTime(reader[ReaderTableFields.Start_Time]),
                            EndTime = reader[ReaderTableFields.Ending_Time] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader[ReaderTableFields.Ending_Time]),
                            IsValid = Convert.ToBoolean(reader[ReaderTableFields.Status])
                        });
                    }
                }
                return readers;
            });
        }
    }
}