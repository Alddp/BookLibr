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

        /// <summary>
        /// 成功的结果，可带数据，自定义的信息
        /// </summary>
        /// <param name="data">附带数据(可选)</param>
        /// <param name="msg">错误消息(可选)</param>
        /// <returns>Success属性的true的OperationResult实例</returns>
        public static OperationResult<TData> Ok(TData data = default, string msg = default) =>
            new OperationResult<TData>(true, data, default, msg);

        /// <summary>
        /// 失败的结果，可带错误代码、数据和自定义的错误信息
        /// </summary>
        /// <param name="errorCode">错误码(可选)</param>
        /// <param name="msg">错误消息(可选)</param>
        /// <param name="data">附带数据(可选)</param>
        /// <returns>Success属性的false的OperationResult实例</returns>
        public static OperationResult<TData> Fail(ErrorCode errorCode = default, string msg = default, TData data = default) =>
        new OperationResult<TData>(false, data, errorCode, msg);
    }
}