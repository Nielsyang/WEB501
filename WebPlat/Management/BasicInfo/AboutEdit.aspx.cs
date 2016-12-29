using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;
using MODEL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.BasicInfo
{
    public partial class AboutEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["Id"];
                if (!String.IsNullOrEmpty(id))
                {
                    int Id = int.Parse(id);
                    AboutManager aboutmanager = new AboutManager();
                    About about = aboutmanager.GetById(Id);
                    title.Value = about.Title;
                    CKEditorControl1.Text = about.Content;
                    Add_time.Value = Convert.ToString(about.Add_time);
                    hidden.Value = Convert.ToString(about.Id);
                }
            }
        }
        protected void edit_About(object sender, EventArgs e)
        {
            string Id = hidden.Value;
            string Title = title.Value;
            string content = CKEditorControl1.Text;
            string add_time = Add_time.Value;
            About about = new About();
            about.Id = Convert.ToInt32(Id);
            about.Title = Title;
            about.Content =HtmlEncoder.Filter(content);
            about.Add_time = Convert.ToDateTime(add_time);
            AboutManager aboutManager = new AboutManager();
            int res = aboutManager.Update(about);
            if (res > -1)
            {
                Response.Write(MessageHelper.showMessage("修改成功！", "About.aspx"));
            }
            else
            {
                Response.Write(MessageHelper.showMessage("修改失败！","AboutEdit.aspx"));
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            title.Value = "";
            CKEditorControl1.Text = "";
            Add_time.Value = "";
        }
    }
}