using Entity.Helpers.Response;

namespace Entity.Helpers.Localization
{
    public static class RequestCultureHelper
    {
        public static ErrorResult GetEqualsResult(string ru, string en, string uz, string equalText, int code)
        {
            string resultText = ru;
            switch (equalText)
            {
                case CultureHelper.UzShortLanguageName:
                    resultText = uz;
                    break;
                case CultureHelper.RuShortLanguageName:
                    resultText = ru;
                    break;
                case CultureHelper.EnShortLanguageName:
                    resultText = en;
                    break;
            }

            return new ErrorResult(code, resultText);
        }

        public static string GetEqualsResult(string ru, string en, string uz, string equalText)
        {
            string resultText = ru;
            switch (equalText)
            {
                case CultureHelper.UzShortLanguageName:
                    resultText = uz;
                    break;
                case CultureHelper.RuShortLanguageName:
                    resultText = ru;
                    break;
                case CultureHelper.EnShortLanguageName:
                    resultText = en;
                    break;
            }

            return resultText;
        }
    }
}
