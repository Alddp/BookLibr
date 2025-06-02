namespace BookModels.Errors {

    public class OperationResult<TData> {
        public bool Success { get; private set; }
        public ErrorCode ErrorCode { get; private set; }

        private readonly string _message = default;

        public string Message {
            get {
                return _message == default
                    ? ErrorMessages.GetMessage(ErrorCode)
                    : _message;
            }
            private set { }
        }

        public TData Data { get; private set; }

        private OperationResult(bool success, TData data, ErrorCode errorCode, string msg = default) {
            Success = success;
            Data = data;
            ErrorCode = errorCode;
            _message = msg;
        }

        // 成功的结果，返回数据
        public static OperationResult<TData> Ok(TData data) =>
            new OperationResult<TData>(true, data, default);

        // 成功的结果，没有数据
        public static OperationResult<TData> Ok() =>
            new OperationResult<TData>(true, default, default);

        public static OperationResult<TData> Fail(ErrorCode errorCode) =>
            new OperationResult<TData>(false, default, errorCode);

        // 失败的结果，带错误代码和对应错误信息
        public static OperationResult<TData> Fail() =>
            new OperationResult<TData>(false, default, default);

        // 失败的结果，带错误代码和自定义的错误信息
        public static OperationResult<TData> Fail(ErrorCode errorCode, string msg) =>
        new OperationResult<TData>(false, default, errorCode, msg);
    }
}