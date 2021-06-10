using Entity.Helpers.Localization;
using Entity.Helpers.Response;
using Microsoft.AspNetCore.Http;

namespace Entity.Helpers
{
    /// <summary>
    /// HttpContext
    /// </summary>
    public static class HttpContextHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static IHttpContextAccessor Accessor;

        /// <summary>
        /// 
        /// </summary>
        public static HttpContext Current => Accessor?.HttpContext;

        /// <summary>
        /// 
        /// </summary>
        public static void SetErrorInBodyCode()
        {
            SetStatusCode(ResponseStatus.ErrorInBody);
        }

        /// <summary>
        /// Установить StatusCode
        /// </summary>
        /// <param name="code"></param>
        public static void SetStatusCode(ResponseStatus  code)
        {
            var responseCode = (int)System.Enum.ToObject(code.GetType(), code);
            SetStatusCode(responseCode);
        }

        /// <summary>
        /// Установить и возвращает StatusCode
        /// </summary>
        /// <param name="code"></param>
        public static int GetStatusCode(ResponseStatus  code)
        {
            var responseCode = (int)System.Enum.ToObject(code.GetType(), code);
            SetStatusCode(responseCode);
            return responseCode;
        }

        /// <summary>
        /// Установить и возвращает StatusCode
        /// </summary>
        /// <param name="code"></param>
        public static int GetStatusCode(int code)
        {
            SetStatusCode(code);
            return code;
        }

        /// <summary>
        /// Установить StatusCode
        /// </summary>
        /// <param name="code"></param>
        public static void SetStatusCode(int code)
        {
           if (Current?.Response != null)
                Current.Response.StatusCode = code;
        }

        /// <summary>
        /// Получает язык по запросу (Нужно указать язык при отправки запроса в Headers. Параметр языка: "Lang" или "Language" или "Accept-Language" или "Content-Language"; Значение параметра одно из них: "ru", "uz", "en")
        /// </summary>
        /// <param name="code"></param>
        public static string GetLanguageValue()
        {
            if (Current?.Response == null)
                return CultureHelper.RuShortLanguageName;
            var languageValue = Current.Request.Headers[LanguageHelper.LanguageKey].ToString();
            if (string.IsNullOrEmpty(languageValue))
                languageValue = Current.Request.Headers[LanguageHelper.ShortLanguageKey].ToString();
            if (string.IsNullOrEmpty(languageValue))
                languageValue = Current.Request.Headers[LanguageHelper.AcceptLanguageKey].ToString();
            if (string.IsNullOrEmpty(languageValue))
                languageValue = Current.Request.Headers[LanguageHelper.ContentLanguageKey].ToString();
            if (string.IsNullOrEmpty(languageValue))
                return CultureHelper.RuShortLanguageName;
            return languageValue;
        }
    }
}
