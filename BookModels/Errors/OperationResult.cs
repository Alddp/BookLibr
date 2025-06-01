using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModels.Errors
{
    public class OperationResult<TError>
    {
        public bool Success { get; private set; }
        public TError ErrorCode { get; private set; }
        public string Message { get; private set; }
        private OperationResult(bool success, TError errorCode, string message = null)
        {
            Success = success;
            ErrorCode = errorCode;
            Message = message;
        }
        public static OperationResult<TError> Ok() =>
            new OperationResult<TError>(true, default);

        public static OperationResult<TError> Fail(TError errorCode, string message = null) =>
            new OperationResult<TError>(false, errorCode, message);
    }
}
