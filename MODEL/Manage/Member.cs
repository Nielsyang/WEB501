using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.Manage
{
    [Serializable()]
     public class Member
    {
        public int id
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string sex
        {
            get;
            set;
        }
        public DateTime? birth
        {
            get;
            set;
        }
        public string degree
        {
            get;
            set;
        }
        public string college
        {
            get;
            set;
        }
        public string major
        {
            get;
            set;
        }
        public string assignment
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }
        public string introduce
        {
            get;
            set;
        }
        public string photo
        {
            get;
            set;
        }
        public DateTime? add_time
        {
            get;
            set;
        }
        public string address
        {
            get;
            set;
        }
    }
}
