﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public partial class ReadOnlyApplicationSettingsSource:IApplicationSettingsGetter
    {
        public string PathName
        {
            get
            {
                return Source.PathName;
            }
        }
        public string Title
        {
            get
            {
                return Source.Title;
            }
        }
    }
}
