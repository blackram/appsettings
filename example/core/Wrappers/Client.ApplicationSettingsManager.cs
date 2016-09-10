using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Wrappers.Client
{
    public class ApplicationSettingsManager : IDisposable
    {

        public void AssignApplicationSettings(bool designMode=false)
        {
            if (ApplicationSettingStore.Settings== null)
                ApplicationSettingStore.Settings = new ClientApplicationSettings(new RawApplicationSettingsSource(), designMode);          
        }

        public void AssignApplicationSettings(ClientApplicationSettings applicationSettings)
        {
            if (ApplicationSettingStore.Settings == null)
                ApplicationSettingStore.Settings = applicationSettings;  
        }

        public void Dispose()
        {
            ApplicationSettingStore.Settings = null;
        }

        public void Refresh(IApplicationSettingsGetter newSettings)
        {
            ApplicationSettingStore.Settings.Refresh(newSettings);
        }
    }
}
