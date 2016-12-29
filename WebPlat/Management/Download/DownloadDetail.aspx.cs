using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;
using MODEL.Manage;

namespace WebPlat.Management.Download
{
    public partial class DownloadDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id = Request.QueryString["Id"];
            if (!String.IsNullOrEmpty(Id))
            {
                int id = int.Parse(Id);
                DownloadBLL download = new DownloadBLL();
                FileDownload filedownload = new FileDownload();
                filedownload = download.GetByid(id);
                Label1.Text = filedownload.filename;
                Label2.Text = filedownload.info;
                Label3.Text = filedownload.url;
                Label4.Text = Convert.ToString(filedownload.add_time);
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Download.aspx");
        }
    }
}