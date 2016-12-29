using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using MODEL;
using System.Web.Script.Serialization;

namespace Test.ajax
{
    /// <summary>
    /// GetHerbByFoemula 的摘要说明
    /// </summary>
    public class GetHerbByFoemula : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int formulaId = Convert.ToInt32(context.Request["formulaId"]);
            FormulaBLL formulaBll = new FormulaBLL();
            var disease = formulaBll.GetHerbsByFormulaId(formulaId);
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