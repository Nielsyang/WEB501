using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.Manage
{
    [Serializable()]
    public class Question
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Subject
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public DateTime? Send_time
        {
            get;
            set;
        }
    }
}
