using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.Manage
{
    [Serializable()]
    public class WebSite
    {
        public int id
        {
            get;
            set;
        }
        public string web_name
        {
            get;
            set;
        }
        public string link
        {
            get;
            set;
        }
        public string logo
        {
            get;
            set;
        }
    }
}
