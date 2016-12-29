using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL.Manage
{	
	[Serializable()]
	public class Admin
	{	
			public int Id
			{
				get;
				set;
			}
			public string Username
			{
				get;
				set;
			}
			public string Password
			{
				get;
				set;
			}
	}
}
