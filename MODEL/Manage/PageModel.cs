using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.Manage
{
    public class PageModel<T>
    {
        //每页显示的记录数 
        public  int rows
        {  
            set;
            get; 
        }
        //当前第几页 
        public int page 
        { 
            set; 
            get; 
        }
        //总共的记录数
        public int total
        {
            set;
            get;
        }
        //每页显示的记录数
        public List<T> list
        {
            set;
            get;
        }
    }
}
