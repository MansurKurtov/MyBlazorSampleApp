using Entity.Helpers.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Entity.Helpers.Response
{
    public class ResponseData
    {
        public HttpResponse Response { get; set; }

        [JsonProperty("statusCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int StatusCode { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        [JsonProperty("result")]
        public object Result { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        [JsonProperty("error")]
        public ErrorResult Error { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Empty
        /// </summary>
        public ResponseData()
        {

        }

        /// <summary>
        /// Empty
        /// </summary>
        public ResponseData( object result, ResponseStatus code)
        {
            StatusCode = HttpContextHelper.GetStatusCode(code);
            Result = result;
        }

        /// <summary>
        /// Возвращает ошибку по тексту
        /// </summary>
        /// <param name="text"></param>
        public ResponseData(string text)
        {
            HttpContextHelper.SetStatusCode(ResponseStatus.BadRequest);
            StatusCode = HttpContextHelper.GetStatusCode(ResponseStatus.BadRequest);
            Error = new ErrorResult((int)ResponseStatus.BadRequest, text);
        }

        /// <summary>
        /// Возвращает ошибку или результат по ResponseStatusCode
        /// </summary>
        public ResponseData(string message, ResponseStatus code)
        {
            HttpContextHelper.SetStatusCode(code);
            StatusCode = HttpContextHelper.GetStatusCode(code);

            switch (StatusCode)
            {
                case 200:
                case 201:
                case 202:
                case 484:
                    StatusCode = HttpContextHelper.GetStatusCode(ResponseStatus.BadRequest);
                    break;
                default:
                    Result = null;
                    break;
            }
            Error = new ErrorResult(StatusCode, message);
        }

        /// <summary>
        /// Возвращает ошибку по ModelState
        /// </summary>
        /// <param name="modelState"></param>
        public ResponseData(ModelStateDictionary modelState)
        {
            try
            {
                StatusCode = HttpContextHelper.GetStatusCode(ResponseStatus.BadRequest);
                var error = modelState.Keys
                        .SelectMany(key => modelState[key]
                                                .Errors
                                                .Select(x => new ValidationError { Message = $"\"{key} -> {x.Exception.Message}\" {RequestCultureHelper.GetEqualsResult("не соответствует", "does not match", "mos kelmaydi", HttpContextHelper.GetLanguageValue())}" }))
                                                .FirstOrDefault();

                if (error != null)
                    Error = new ErrorResult(StatusCode, error.Message);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Возвращает результат по ErrorResult
        /// </summary>
        /// <param name="isSuccess"></param>
        public ResponseData(bool isSuccess)
        {
            StatusCode = HttpContextHelper.GetStatusCode(ResponseStatus.OK);
            Result = new { success = isSuccess };
        }

        /// <summary>
        /// Возвращает результат по ResponseCoreData
        /// </summary>
        /// <param name="response"></param>
        /// <param name="code"></param>
        public ResponseData(ResponseData response, ResponseStatus code)
        {
            StatusCode = HttpContextHelper.GetStatusCode(code);
            Result = response.Result;
            Error = response.Error;
        }

        /// <summary>
        /// Возвращает ошибку по ErrorResult
        /// </summary>
        /// <param name="errorResult"></param>
        /// <param name="code"></param>
        public ResponseData(ErrorResult errorResult, ResponseStatus code)
        {
            StatusCode = HttpContextHelper.GetStatusCode(code);
            Error = errorResult;
        }

        /// <summary>
        /// Возвращает ошибку (кроме 200,201,202,484)
        /// </summary>
        /// <param name="code"></param>
        public ResponseData(ResponseStatus code)
        {
            StatusCode = HttpContextHelper.GetStatusCode(code);
            switch (StatusCode)
            {
                case 200:
                case 201:
                case 202:
                case 484:
                    Result = new { success = true };
                    break;
                case 401:

                    Error = RequestCultureHelper.GetEqualsResult("Не авторизован", "Unauthorized", "Avtorizatsiyadan o'tilmagan", HttpContextHelper.GetLanguageValue(), StatusCode);
                    break;
                default:
                    Result = new { success = false };
                    break;

            }
        }

        /// <summary>
        /// Возвращает результат по ResponseResult
        /// </summary>
        /// <param name="code"></param>
        public ResponseData(ResponseResult model)
        {
            StatusCode = HttpContextHelper.GetStatusCode(ResponseStatus.OK);
            Result = model;
        }

        /// <summary>
        /// Возвращает ошибку по ErrorResult
        /// </summary>
        /// <param name="errorResult"></param>
        public ResponseData(ErrorResult errorResult)
        {
            StatusCode = HttpContextHelper.GetStatusCode(ResponseStatus.BadRequest);
            Error = errorResult;
        }

        /// <summary>
        /// Возвращает ошибку по Exception
        /// </summary>
        /// <param name="ex"></param>
        public ResponseData(Exception ex)
        {
            StatusCode = HttpContextHelper.GetStatusCode(ResponseStatus.BadRequest);
            Error = new ErrorResult(ex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        public static implicit operator ResponseData(ErrorResult error) => new ResponseData(error);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ResponseData(bool value) => new ResponseData(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelState"></param>
        public static implicit operator ResponseData(ModelStateDictionary modelState) => new ResponseData(modelState);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public static implicit operator ResponseData(Exception ex) => new ResponseData(ex);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public static implicit operator ResponseData(string str) => new ResponseData(str);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        public static implicit operator ResponseData(ResponseStatus code) => new ResponseData(code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public static implicit operator ResponseData(ResponseResult model) => new ResponseData(model);
    }
}
