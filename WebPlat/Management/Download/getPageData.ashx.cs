using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL.Manage;
using BLL.Manage;
using System.Web.Script.Serialization;

namespace WebPlat.Management.Download
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
            PageModel<FileDownload> pagemodel = new PageModel<FileDownload>();
            pagemodel.rows = intPageSize;
            pagemodel.page = start;
            string strJson = GetDataToJson(pagemodel);
            context.Response.Write(strJson);
        }
        public string GetDataToJson(PageModel<FileDownload> pagemodel)
        {
            string strResult = string.Empty;
            DownloadBLL  downloadmanage = new DownloadBLL();
            pagemodel.list =downloadmanage.GetPagedData(pagemodel.page, pagemodel.rows);
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