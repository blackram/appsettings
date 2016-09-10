using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public partial class ReadWriteApplicationSettingsSource : ApplicationSettingsSource, IApplicationSettingsGetter
    {
        public ReadWriteApplicationSettingsSource(IApplicationSettingsGetter source) : base(source) { }        
    }    
}
