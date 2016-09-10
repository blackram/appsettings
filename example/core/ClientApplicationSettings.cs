using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class ClientApplicationSettings
    {
        ApplicationSettingsSource ApplicationSettingsSource;

        public ClientApplicationSettings(IApplicationSettingsGetter source, bool designMode= false)
        {
            if (designMode)
                ApplicationSettingsSource = new ReadWriteApplicationSettingsSource(source);
            else
                ApplicationSettingsSource = new ReadOnlyApplicationSettingsSource(source);
        }

        public IApplicationSettingsGetter ApplicationSettings()
        {
            return (IApplicationSettingsGetter)ApplicationSettingsSource;
        }
        
        public void Refresh(IApplicationSettingsGetter source)
        {
            ApplicationSettingsSource.Refresh(source);
        }        
    }
}
