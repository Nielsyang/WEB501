using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPlat.Common;
using MODEL.Manage;
using BLL.Manage;

namespace WebPlat.Management.BasicInfo
{
    public partial class aboutAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void about_add(object sender, EventArgs e)
        {
            string Title = title.Value;
            string content = HtmlEncoder.Filter(CKEditorControl1.Text);
            string add_time = Add_time.Value;
            About about = new About();
            about.Title = Title;
            about.Content = content;
            about.Add_time = Convert.ToDateTime(add_time);
            AboutManager aboutManager = new AboutManager();
            if (aboutManager.Add(about) != null)
            {
                Response.Write(MessageHelper.showMessage("添加成功！", "About.aspx"));
            }
            else
            {
                Response.Write(MessageHelper.showMessage("添加失败！", "aboutAdd.aspx"));
            }
        }
    }
}