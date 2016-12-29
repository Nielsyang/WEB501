using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using MODEL;

namespace WebPlat.ajax
{
    /// <summary>
    /// GetDiseaseName 的摘要说明
    /// </summary>
    public class GetAllTissueName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            TissueBLL TissueBll = new TissueBLL();
            string tissue = TissueBll.GetAllTissueName();
            context.Response.Write(tissue);
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