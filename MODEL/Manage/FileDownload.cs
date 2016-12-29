using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.Manage
{
    public class FileDownload
    {
        public int id
        {
            get;
            set;
        }
        public string filename
        {
            get;
            set;
        }
        public string info
        {
            get;
            set;
        }
        public string url
        {
            get;
            set;
        }
        public DateTime? add_time
        {
            get;
            set;
        }
    }
}
