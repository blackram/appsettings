using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Wrappers.Client
{
    public class ApplicationSettingsManager : IDisposable
    {
        public void CreateApplicationSettings(bool designMode=false)
        {
            ApplicationSettingStore.Settings = new ClientApplicationSettings(new RawApplicationSettingsSource(), designMode);          
        }

        public void Dispose()
        {
            ApplicationSettingStore.Settings = null;
        }        
    }
}
