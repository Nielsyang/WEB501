using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL.Manage;
using BLL.Manage;

namespace WebPlat.Management.publication
{
    public partial class DetailPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id=Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(Id))
            {
                int id = int.Parse(Id);
                Publication  pub = new Publication();
                PublicationBLL publicationBll = new PublicationBLL();
                pub = publicationBll.GetByid(id);
                Label1.Text = pub.paper_name;
                Label2.Text = pub.Author;
                Label3.Text = pub.Abstract;
                Label4.Text = pub.keyWord;
                Label5.Text = pub.type;
                Label6.Text = pub.level;
                Label7.Text = pub.url;
                Label8.Text = Convert.ToString(pub.publish_time);
            }
        }
    }
}