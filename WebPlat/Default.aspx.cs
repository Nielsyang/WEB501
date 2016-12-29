using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MODEL;

namespace WebPlat
{
    public partial class  Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string user_ip = Request.ServerVariables.Get("Remote_Addr").ToString();
                UserInfoBLL push_userinfo = new UserInfoBLL();
                push_userinfo.PushUserInfo(user_ip);
            }
        }
    }

}
