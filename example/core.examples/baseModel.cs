using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Client = core.Wrappers.Client;

namespace core.examples
{
    /// <summary>
    /// An example where a single model/controller initialises the application settings manager. In practice
    /// the initialisation would be in a startup or global asax section.
    /// </summary>
    public class BaseModel
    {
        protected IApplicationSettingsGetter ApplicationSettings => Client.ApplicationSettingsContainer.Settings;
        
        public BaseModel(bool designMode=false)
        {
            var manager = new Client.ApplicationSettingsManager();
            manager.AssignApplicationSettings(new ClientApplicationSettings(new RawApplicationSettingsSource(), designMode));
        }
    }
}
