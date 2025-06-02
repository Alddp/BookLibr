namespace BookModels.Errors {

    public class OperationResult<TData, TError> {
        public bool Success { get; private set; }
        public TError ErrorCode { get; private set; }
        public string Message { get; private set; }
        public TData Data { get; private set; }

        private OperationResult(bool success, TData data, TError errorCode, string message) {
            Success = success;
            Data = data;
            ErrorCode = errorCode;
            Message = message;
        }

        // 成功的结果，返回数据
        public static OperationResult<TData, TError> Ok(TData data) =>
            new OperationResult<TData, TError>(true, data, default, null);

        // 成功的结果，没有数据
        public static OperationResult<TData, TError> Ok() =>
            new OperationResult<TData, TError>(true, default, default, null);

        // 失败的结果，带错误代码和信息
        public static OperationResult<TData, TError> Fail(TError errorCode, string message = null) =>
            new OperationResult<TData, TError>(false, default, errorCode, message);

        // 失败的结果，没有错误信息
        public static OperationResult<TData, TError> Fail() =>
            new OperationResult<TData, TError>(false, default, default, null);
    }
}