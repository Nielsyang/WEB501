using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;

namespace WebPlat.Management.Administrator
{
    public partial class admin : System.Web.UI.Page
    {
        protected int total;
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminBLL adminbll = new AdminBLL();
            total = adminbll.GetTotalCount();
            
        }
    }
}