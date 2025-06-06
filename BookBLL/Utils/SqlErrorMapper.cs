using BookModels.Errors;
using System.Data.SqlClient;

namespace BookBLL.Utils {

    public static class SqlErrorMapper {

        public static ErrorCode Map(SqlException ex) {
            switch (ex.Number) {
                case 2627:
                    return ErrorCode.DuplicateKey; // 主键/唯一键冲突
                case 2601:
                    return ErrorCode.DuplicateKey; // 唯一索引冲突
                case 547:
                    return ErrorCode.ForeignKeyViolation; //外键冲突
            }
            return ErrorCode.DatabaseError; // 数据库错误
        }
    }
}