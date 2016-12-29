using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;

namespace WebPlat.Management.BasicInfo
{
    public partial class  About2: System.Web.UI.Page
    {
        protected int total;
        protected void Page_Load(object sender, EventArgs e)
        {
            AboutManager aboutmanager = new AboutManager();
            total=aboutmanager.GetTotalCount();
        }
    }
}