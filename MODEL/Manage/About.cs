using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MODEL.Manage
{
    [Serializable()]
    public class About
    {
        public int Id
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }
        public DateTime? Add_time
        {
            get;
            set;
        }
    }
}