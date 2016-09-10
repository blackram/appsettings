using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class ClientApplicationSettings
    {
        ReadWriteApplicationSettingsSource DesignModeSource;
        ReadOnlyApplicationSettingsSource ReadOnlySource;
        bool DesignMode;

        public ClientApplicationSettings(IApplicationSettingsGetter source, bool designMode= false)
        {
            DesignMode = designMode;

            if (DesignMode)
                DesignModeSource = new ReadWriteApplicationSettingsSource(source);
            else
                ReadOnlySource = new ReadOnlyApplicationSettingsSource(source);
        }

        public IApplicationSettingsGetter ApplicationSettings()
        {               
            if (DesignMode)
                return DesignModeSource;
            else
                return ReadOnlySource;
        }
        
        public void Refresh(IApplicationSettingsGetter source)
        {
            if (DesignMode)
                DesignModeSource.Refresh(source);
            else
                ReadOnlySource.Refresh(source);
        }        
    }
}
