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
    public class GetAllFormulaName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            FormulaBLL FormulaBll = new FormulaBLL();
            string formula = FormulaBll.GetAllFormulaName();
            context.Response.Write(formula);
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