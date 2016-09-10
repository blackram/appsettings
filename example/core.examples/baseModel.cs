using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Client = core.Wrappers.Client;

namespace core.examples
{
    public class BaseModel
    {
        protected IApplicationSettingsGetter ApplicationSettings => Client.ApplicationSettingsContainer.Settings;
        
        public BaseModel(bool designMode=false)
        {
            var manager = new Wrappers.Client.ApplicationSettingsManager();
            manager.CreateApplicationSettings(designMode);
        }
    }
}
