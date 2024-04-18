using Newtonsoft.Json;

namespace SimpleSendKeys.Entities
{
    public class FunctionResponse
    {
        #region Properties
        public bool Error { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        #endregion

        #region Constructors
        public FunctionResponse()
        {
            Error = false;
        }

        public FunctionResponse(bool error)
        {
            Error = error;
        }

        public FunctionResponse(bool error, string message)
        {
            Error = error;
            Message = message;
        }

        public FunctionResponse(bool error, string message, string stackTrace)
        {
            Error = error;
            Message = message;
            StackTrace = stackTrace;
        }

        public FunctionResponse(Exception exception)
        {
            Error = true;
            Message = exception.Message;
            StackTrace = exception.StackTrace;
        }
        #endregion

        #region Methods
        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.None);
        #endregion
    }
}
