using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Helpers.Response
{
    /// <summary>
    /// Возвращает результат по модел "ResponseResult"
    /// </summary>
    public class ResponseResult
    {
        public ResponseResult(bool success, object data, int total, string message)
        {
            Success = success;
            Data = data;
            Total = total;
            Message = message;
        }

        public ResponseResult(object data)
        {
            Success = true;
            Data = data;
            Total = 1;
            Message = string.Empty;
        }

        public ResponseResult(string message)
        {
            Success = true;
            Message = message;
        }

        /// <summary>
        /// Результат данных
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }

        /// <summary>
        /// Статус успешности
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Сообщение о результате
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Общее кол-во данных
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
