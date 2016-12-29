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
    public class GetDiseaseName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            OMIMBLL OMIMBll = new OMIMBLL();
            string disease = OMIMBll.GetAllDiseaseName();
            context.Response.Write(disease);
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