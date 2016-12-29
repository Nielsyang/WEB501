using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;

namespace WebPlat.Management.Download
{
    public partial class Download : System.Web.UI.Page
    {
        protected int total;
        protected void Page_Load(object sender, EventArgs e)
        {
            DownloadBLL download = new DownloadBLL();
            total=download.GetTotalCount();
        }
    }
}