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
    public class GetAllHerbName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HerbBLL HerbBll = new HerbBLL();
            string herb = HerbBll.GetAllHerbName_Cn();
            context.Response.Write(herb);
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