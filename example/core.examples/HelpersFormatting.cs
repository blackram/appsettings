using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.examples
{
    public static class HelpersFormatting
    {
        private static IApplicationSettingsGetter ApplicationSettings = new ClientApplicationSettings(new RawApplicationSettingsSource()).ApplicationSettings();

        public static string FormatName(string first, string last)
        {
            return $"{ApplicationSettings.Title} {first} {last}";
        }
    }
}
