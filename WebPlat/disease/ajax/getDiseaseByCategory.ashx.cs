using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPlat.BLL;
using System.Web.Script.Serialization;
namespace WebPlat.ajax
{
    /// <summary>
    /// _1 的摘要说明
    /// </summary>
    public class _1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Category = context.Request["Category"];
            DiseaseBll disdal = new DiseaseBll();
            var disease = disdal.getDiseasesByCategory(Category);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(disease);
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