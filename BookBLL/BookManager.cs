using System;
using System.Data.SqlClient;
using System.Text;

namespace BookBLL
{
    public class BookManager
    {
        public static SqlDataReader SearchBook(string info, out string errorMessage)
        {
            // 初始化out参数
            errorMessage = string.Empty;

            try
            {
                // 参数验证
                if (string.IsNullOrWhiteSpace(info))
                {
                    errorMessage = "搜索关键字不能为空";
                    return null;
                }

                // 调用DAL层方法
                return BookDAL.BookService.SearchBook(info);
            }
            catch (SqlException sqlEx)
            {
                // 数据库异常处理
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("数据库操作失败:");
                sb.AppendLine($"错误代码: {sqlEx.Number}");
                sb.AppendLine($"错误信息: {sqlEx.Message}");
                if (sqlEx.InnerException != null)
                {
                    sb.AppendLine($"内部异常: {sqlEx.InnerException.Message}");
                }
                errorMessage = sb.ToString();
                return null;
            }
            catch (Exception ex)
            {
                // 其他异常处理
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("系统发生异常:");
                sb.AppendLine($"异常类型: {ex.GetType().Name}");
                sb.AppendLine($"错误信息: {ex.Message}");
                if (ex.InnerException != null)
                {
                    sb.AppendLine($"内部异常: {ex.InnerException.Message}");
                }
                sb.AppendLine($"堆栈跟踪: {ex.StackTrace}");
                errorMessage = sb.ToString();
                return null;
            }
        }
    }
}