using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPlat.Common;
using BLL.Manage;

namespace WebPlat.Management.Administrator
{
    public partial class login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_click(object sender, EventArgs e)
        {
            string userName = username.Value;
            string password = StringMD5.MD5(passWord.Value);
            string Remember_me = remember_me.Value;
            AdminBLL adminBll = new AdminBLL();
            if (adminBll.CheckLogin(userName, password))
            {
                Session["username"] = userName;
                Response.Redirect("../index.aspx");
            }
            else
            {
                Response.Write(MessageHelper.showMessage("您输入的用户名或密码错误!", "login.aspx"));
            }
        }
    }
}