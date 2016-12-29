using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;
using MODEL.Manage;

namespace WebPlat.Management.BasicInfo
{
    public partial class AboutDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id=Request["Id"];
            AboutManager aboutmanager = new AboutManager();
            if(!String.IsNullOrEmpty(Id))
            {
                int id=int.Parse(Id);
                About about=aboutmanager.GetById(id);
                Label1.Text = about.Title;
                Label2.Text = about.Content;
                Label3.Text =Convert.ToString(about.Add_time);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("About.aspx");
        }
    }
}