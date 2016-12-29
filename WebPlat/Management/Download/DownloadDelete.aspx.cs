using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.Download
{
    public partial class DownloadDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id=Request.QueryString["Id"];
            if (!String.IsNullOrEmpty(Id))
            {
                int id = int.Parse(Id);
                DownloadBLL downBll = new DownloadBLL();
                int res=downBll.DeleteByid(id);
                if (res > -1)
                {
                    Response.Write(MessageHelper.showMessage("删除成功！", "Download.aspx"));
                }
                else
                {
                    Response.Write(MessageHelper.showMessage("删除失败！","Download.aspx"));
                }
            }
        }
    }
}