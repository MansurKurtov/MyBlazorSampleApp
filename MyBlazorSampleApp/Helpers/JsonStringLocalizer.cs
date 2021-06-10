using MyBlazorSampleApp.Localization.Models;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MyBlazorSampleApp.Helpers
{
    public class JsonStringLocalizer : IJsonStringLocalizer
    {
        private List<JsonLocalization> localization = new List<JsonLocalization>();
        private CultureInfo cultureInfo;
        public JsonStringLocalizer()
        {
            var serializer = new JsonSerializer();
            localization = JsonConvert.DeserializeObject<List<JsonLocalization>>(File.ReadAllText(@"Localization\Data\lan.json"));
        }

        public JsonStringLocalizer(CultureInfo culture)
        {
            cultureInfo = culture;
            var serializer = new JsonSerializer();
            localization = JsonConvert.DeserializeObject<List<JsonLocalization>>(File.ReadAllText(@"Localization\Data\lan.json"));
        }


        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return localization.Where(l => l.LocalizedValue.Keys.Any(lv => lv == CultureInfo.CurrentCulture.Name)).Select(l => new LocalizedString(l.Key, l.LocalizedValue[CultureInfo.CurrentCulture.Name], true));
        }

        public IStringLocalizer WithCulture(CultureInfo culture) => null;
        public void SetCulture(string name)
        {
            var c = new CultureInfo(name);
            CultureInfo.CurrentCulture = c;
            //contextAccessor.HttpContext.Response.Cookies.Append(name, name);
        }
        private string GetString(string name)
        {
            var query = localization.Where(l => l.LocalizedValue.Keys.Any(lv => lv == CultureInfo.CurrentCulture.Name));
            var value = query.FirstOrDefault(l => l.Key == name);
            return value.LocalizedValue[CultureInfo.CurrentCulture.Name];
        }
    }
}
