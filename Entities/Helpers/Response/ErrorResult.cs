using Newtonsoft.Json;
using System;

namespace Entity.Helpers.Response
{
    /// <summary>
    /// Возвращает ошибку по модел "ErrorResult"
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Code
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Only message
        /// </summary>
        /// <param name="message"></param>
        public ErrorResult(string message)
        {
            Code = (int)ResponseStatus.BadRequest;
            Message = message;
        }

        /// <summary>
        /// Code and Message
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ErrorResult(int code, string message)
        {
            Code = HttpContextHelper.GetStatusCode(code);
            Message = message;
        }

        /// <summary>
        /// ResponseStatusCode and Message
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ErrorResult(ResponseStatus code, string message)
        {
            Code = HttpContextHelper.GetStatusCode(code);
            Message = message;
        }

        /// <summary>
        /// Exception
        /// </summary>
        /// <param name="ex"></param>
        public ErrorResult(Exception ex)
        {
            Code = HttpContextHelper.GetStatusCode(ResponseStatus.BadRequest);
            Message = ex.Message+" "+ex.InnerException?.Message;
        }
    }
}
