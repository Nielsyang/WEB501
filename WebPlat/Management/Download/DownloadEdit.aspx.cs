using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL.Manage;
using BLL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.Download
{
    public partial class DownloadEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Id = Request.QueryString["Id"];
                if (!String.IsNullOrEmpty(Id))
                {
                    int id = int.Parse(Id);
                    FileDownload fileDownload = new FileDownload();
                    DownloadBLL downloadBll = new DownloadBLL();
                    fileDownload = downloadBll.GetByid(id);
                    hid.Value = Convert.ToString(fileDownload.id);
                    filename.Value = fileDownload.filename;
                    fileinfo.Value = fileDownload.info;
                    fileurl.Value = fileDownload.url;
                }
            }
        }

        protected void midify_Click(object sender, EventArgs e)
        {
            string Id = hid.Value;
            string fileName = filename.Value;
            string fileInfo = fileinfo.Value;
            string fileUrl = fileurl.Value;
            FileDownload fileDownload = new FileDownload();
            fileDownload.filename = fileName;
            fileDownload.info = fileInfo;
            fileDownload.url = fileUrl;
            fileDownload.add_time = DateTime.Now;
            if (!String.IsNullOrEmpty(Id))
            {
                DownloadBLL downBll = new DownloadBLL();
                int res= downBll.Update(fileDownload);
                if (res > -1)
                {
                    Response.Write(MessageHelper.showMessage("修改成功！", "Download.aspx"));
                }
                else
                {
                    Response.Write(MessageHelper.showMessage("修改失败！", "DownloadEdit.aspx?Id=" + Id));
                }
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            filename.Value = "";
            fileinfo.Value = "";
            fileurl.Value = "";
        }
    }
}