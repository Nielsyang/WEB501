using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPlat.Common
{
    public class MessageHelper
    {
        public static string showMessage(string message,string url)
        {
            return "<script language='javascript'>alert('" + message + "');window.location.href='" + url + "';</script>";
        }
        public static string showMessage(string message)
        {
            return "<script language='javascript'>alert('"+message+"');</script>";
        }
    }
}