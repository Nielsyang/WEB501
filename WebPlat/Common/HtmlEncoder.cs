using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace WebPlat.Common
{
    public class HtmlEncoder
    {
        public static string Filter(String message) {

           if (message == null)
            return  null ; 
           if(message.Contains("&lt;"))
           {
               message=message.Replace("&lt;","<");
           }
            if(message.Contains("&gt;"))
            {
                message=message.Replace("&gt;",">");
            }
            if(message.Contains("&amp;"))
            {
                message=message.Replace("&amp;","&");
            }
            if(message.Contains("&quot;"))
            {
                message=message.Replace("&quot;","\"");
            }
            return message;
        }
    }
}