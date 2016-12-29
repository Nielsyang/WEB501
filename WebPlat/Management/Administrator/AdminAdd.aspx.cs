using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Script.Serialization;
using BLL.Manage;
using MODEL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.Administrator
{
    public partial class AdminAdd : System.Web.UI.Page
    {
        protected string jsonAdmin = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminBLL adminBll = new AdminBLL();
            List<Admin> admins = adminBll.GetAll();
            StringBuilder sb = new StringBuilder();
            foreach (Admin admin in admins)
            {
                sb.Append(admin.Username+",");
            }
            jsonAdmin = sb.ToString().Substring(0,sb.Length-1);
        }

        protected void admin_Add(object sender, EventArgs e)
        {
            string userName= username.Value;
            string password = StringMD5.MD5(pwd.Value);
            AdminBLL adminBll = new AdminBLL();
            Admin admin = new Admin();
            admin.Username = userName;
            admin.Password = password;
            if (adminBll.Add(admin) != null)
            {
                Response.Write(MessageHelper.showMessage("添加管理员成功！", "Admin.aspx"));
            }
            else
            {
                Response.Write(MessageHelper.showMessage("添加管理员失败！", "AdminAdd.aspx"));
            }
        }
    }
}