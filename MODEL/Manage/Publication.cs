using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.Manage
{
   public  class Publication
    {

        public int id
			{
				get;
				set;
			}
			public string paper_name
			{
				get;
				set;
			}
			public string level
			{
				get;
				set;
			}
			public string type
			{
				get;
				set;
			}
			public string Abstract
			{
				get;
				set;
			}
			public DateTime? publish_time
			{
				get;
				set;
			}
			public string url
			{
				get;
				set;
			}
			public string Author
			{
				get;
				set;
			}
			public string keyWord
			{
				get;
				set;
			}
    }
}
