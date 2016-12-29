using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using MODEL;
//using System.Web.Script.Serialization;


namespace WebPlat.ajax
{
    /// <summary>
    /// GetCompoundAndHerb 的摘要说明
    /// </summary>
    public class GetCompoundAndHerb : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = Convert.ToString(context.Request["analyse_type"]);
            if (type == "Herb")
            {
                HerbBLL herbBll = new HerbBLL();
                string herb = herbBll.GetAllHerbName();
                context.Response.Write(herb);
            }
            if (type == "Compound")
            {
                CompoundBLL compoundBll = new CompoundBLL();
                string compound = compoundBll.GetAllCompoundName();
                context.Response.Write(compound);
            }

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