using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class ApplicationSettingsSource
    {
        protected IApplicationSettingsGetter Source;

        public ApplicationSettingsSource(IApplicationSettingsGetter source)
        {
            Source = source;
        }

        public void Refresh(IApplicationSettingsGetter source)
        {
            Source = source;
        }
    }
}
