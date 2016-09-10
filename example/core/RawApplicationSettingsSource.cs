using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{   
    /// <summary>
    /// Represents a source of application setings that can not be written to by any of the store implementations
    /// </summary>
    public partial class RawApplicationSettingsSource : IApplicationSettingsGetter
    {
        public virtual string PathName => @"c:\Help\";
        public virtual string Title => "Ms";

        //public bool IsConfigured => true;

        //public  int ConfigurationCount => 1;
    }
}
