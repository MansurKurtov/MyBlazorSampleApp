using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace MyBlazorSampleApp.Helpers
{
    public interface IJsonStringLocalizer
    {
        LocalizedString this[string name] { get; }
        LocalizedString this[string name, params object[] arguments] { get; }

        IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures);
        void SetCulture(string name);
        IStringLocalizer WithCulture(CultureInfo culture);
    }
}