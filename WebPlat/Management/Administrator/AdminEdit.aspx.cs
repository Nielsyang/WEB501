using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;
using MODEL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.Administrator
{
    public partial class AdminEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Id = Request.QueryString["Id"];
                if (!String.IsNullOrEmpty(Id))
                {
                    int id = int.Parse(Id);
                    AdminBLL adminbll = new AdminBLL();
                    Admin admin = adminbll.GetById(id);
                    username.Value = admin.Username;
                    username.Disabled = true;
                    hid.Value = Convert.ToString(admin.Id);
                }
            }
        }

        protected void admin_Edit(object sender, EventArgs e)
        {
            string Id = hid.Value;
            int id = int.Parse(Id);
            string oldpwd = Request.Form["oldpwd"];
            string newpwd = Request.Form["newpwd"];
            AdminBLL adminbll = new AdminBLL();
            Admin admin = new Admin();
            if (StringMD5.MD5(oldpwd) == adminbll.GetById(id).Password)
            {
                admin.Id = id;
                admin.Password = StringMD5.MD5(newpwd);
                int res = adminbll.Update(admin);
                if (res > -1)
                {
                    Response.Write(MessageHelper.showMessage("修改成功！", "Admin.aspx"));
                }
                else
                {
                    Response.Write(MessageHelper.showMessage("修改失败！", "AdminEdit.aspx"));
                }
            }
            else
            {
                Response.Write(MessageHelper.showMessage("旧密码输入不正确，请重新输入！", "AdminEdit.aspx?Id=" + id));
            }
        }
    }
}