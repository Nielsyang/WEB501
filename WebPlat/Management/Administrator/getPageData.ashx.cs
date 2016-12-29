using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL.Manage;
using System.Web.Script.Serialization;
using BLL.Manage;

namespace WebPlat.Management.Administrator
{
    /// <summary>
    /// getPageData 的摘要说明
    /// </summary>
    public class getPageData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int intPageSize = int.Parse(context.Request["rows"].ToString());
            int intCurrentPage = int.Parse(context.Request["page"].ToString());
            int start = (intCurrentPage - 1) * intPageSize;
            PageModel<Admin> pagemodel = new PageModel<Admin>();
            pagemodel.rows = intPageSize;
            pagemodel.page = start;
            string strJson = GetDataToJson(pagemodel);
            context.Response.Write(strJson);
        }
        public string GetDataToJson(PageModel<Admin> pagemodel)
        {
            string strResult = string.Empty;
            AdminBLL adminmanage = new AdminBLL();
            pagemodel.list =adminmanage.GetPagedData(pagemodel.page, pagemodel.rows);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            strResult = jss.Serialize(pagemodel.list);
            return strResult;
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