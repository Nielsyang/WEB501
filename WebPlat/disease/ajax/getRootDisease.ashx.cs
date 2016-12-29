using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebPlat.BLL;

namespace WebPlat.ajax
{
    /// <summary>
    /// _2 的摘要说明
    /// </summary>
    public class _2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            DiseaseBll disbll = new DiseaseBll();
            var dismodel = disbll.getAllRoot();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(dismodel);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}