using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Wrappers.Client
{
    public static class ApplicationSettingsContainer
    {
        public static IApplicationSettingsGetter Settings
        {
            get
            {
                if (ApplicationSettingStore.Settings==null)
                    throw new ArgumentNullException("ClientSettings must be initiliased globally via ApplicationSettingsManager before first call");
                return ApplicationSettingStore.Settings.ApplicationSettings();
            }
        }
    }
}
