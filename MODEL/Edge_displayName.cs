using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class Edge_displayName
    {
        private string _dB_ID_displayName;
        private string _hasEvent_displayName;

        public string DB_ID_displayName
        {
            get { return _dB_ID_displayName; }
            set { _dB_ID_displayName = value; }
        }
        public string HasEvent_displayName
        {
            get { return _hasEvent_displayName; }
            set { _hasEvent_displayName = value; }
        }
    }
}
