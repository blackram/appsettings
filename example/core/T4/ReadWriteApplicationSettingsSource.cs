﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public partial class ReadWriteApplicationSettingsSource : IApplicationSettingsSetter
    {
        private string localPathName = null;

        public string PathName
        {
            get
            {
                if (localPathName == null)
                    localPathName = Source.PathName;
                return localPathName;
            }
            set
            {
                localPathName = value;
            }
        }

        private string localTitle = null;

        public string Title
        {
            get
            {
                if (localTitle == null)
                    localTitle = Source.Title;
                return localTitle;
            }
            set
            {
                localTitle = value;
            }
        }
    }
}
