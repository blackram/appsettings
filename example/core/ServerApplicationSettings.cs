using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class ServerApplicationSettings
    {
        ReadOnlyApplicationSettingsSource ReadOnlySource;

        public ServerApplicationSettings(IApplicationSettingsGetter source)
        {
            ReadOnlySource = new ReadOnlyApplicationSettingsSource(source);
        }

        public IApplicationSettingsGetter ApplicationSettings()
        {           
            return ReadOnlySource;
        }
        
        public void Refresh(IApplicationSettingsGetter source)
        {
            ReadOnlySource.Refresh(source);
        }        
    }
}
