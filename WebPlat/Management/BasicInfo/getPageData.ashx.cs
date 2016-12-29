using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL.Manage;
using System.Web.Script.Serialization;
using BLL.Manage;

namespace WebPlat.Management.BasicInfo
{
    /// <summary>
    /// getPageData2 的摘要说明
    /// </summary>
    public class getPageData2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int intPageSize = int.Parse(context.Request["rows"].ToString());
            int intCurrentPage = int.Parse(context.Request["page"].ToString());
            int start = (intCurrentPage - 1) * intPageSize;
            PageModel<About>  pagemodel = new PageModel<About>();
            pagemodel.rows = intPageSize;
            pagemodel.page = start;
            string strJson = GetDataToJson(pagemodel);
            context.Response.Write(strJson);
        }
        public string GetDataToJson(PageModel<About> pagemodel)
        {
            string strResult = string.Empty;
            AboutManager aboutmanage = new AboutManager();
            pagemodel.list =aboutmanage.GetPagedData(pagemodel.page, pagemodel.rows);
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