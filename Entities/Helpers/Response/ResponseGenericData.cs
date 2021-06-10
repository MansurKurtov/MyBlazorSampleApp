using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Entity.Helpers.Response
{
    public class ResponseData<T> : ResponseData where T : class
    {
        private T _result;

        public new T Result
        {
            get => _result;
            set
            {
                _result = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        public ResponseData(string error)
        {
            HttpContextHelper.SetStatusCode(ResponseStatus.BadRequest);
            StatusCode = 400;
            Result = null;
            Error = new ErrorResult(400, error);
        }

        public ResponseData(ResponseStatus responseStatusCode)
        {
            StatusCode = HttpContextHelper.GetStatusCode(responseStatusCode);
            Result = null;

            switch (StatusCode)
            {
                case 401:
                    Error = new ErrorResult(StatusCode, "Не существует пользователь");
                    break;
                case 400:
                    Error = new ErrorResult(StatusCode, "Проверьте правильность передающие параметры");
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public ResponseData(T result)
        {
            HttpContextHelper.SetStatusCode(ResponseStatus.OK);
            Result = result;
        }

        /// <summary>
        /// Model State
        /// </summary>
        /// <param name="modelState"></param>
        public ResponseData(ModelStateDictionary modelState)
        {
            var code = HttpContextHelper.GetStatusCode(ResponseStatus.BadRequest);

            var error = modelState.Keys
                    .SelectMany(key => modelState[key]
                                            .Errors
                                            .Select(x => new ValidationError { Message = $"\"{key} -> {x.ErrorMessage}\"" }))
                                            .FirstOrDefault();

            if (error != null)
                Error = new ErrorResult(code, error.Message);
        }

        public ResponseData(System.Exception ex)
        {
            StatusCode = HttpContextHelper.GetStatusCode(ResponseStatus.Conflict);
            Error = new ErrorResult((int)ResponseStatus.Conflict, ex.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        public static implicit operator ResponseData<T>(string error) => new ResponseData<T>(error);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ResponseData<T>(T value) => new ResponseData<T>(value);
        public static implicit operator ResponseData<T>(ModelStateDictionary value) => new ResponseData<T>(value);
        public static implicit operator ResponseData<T>(System.Exception value) => new ResponseData<T>(value);
        public static implicit operator ResponseData<T>(ResponseStatus value) => new ResponseData<T>(value);
    }
}

