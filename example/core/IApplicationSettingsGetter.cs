using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public interface IApplicationSettingsGetter
    {
       string PathName { get; }
       string Title { get; }
    }
}
