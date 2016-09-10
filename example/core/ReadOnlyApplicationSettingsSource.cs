using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public partial class ReadOnlyApplicationSettingsSource : ApplicationSettingsSource
    {
        public ReadOnlyApplicationSettingsSource(IApplicationSettingsGetter source) : base(source) { }
    }
}
