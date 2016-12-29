using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.member
{
    public partial class MemberDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id=Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(Id))
            {
                int id = int.Parse(Id);
                MemberBLL memberBll = new MemberBLL();
                int res = memberBll.DeleteByid(id);
                if (res > -1)
                {
                    Response.Write(MessageHelper.showMessage("删除成功！", "Member.aspx"));
                }
                else
                {
                    Response.Write(MessageHelper.showMessage("删除失败！", "Member.aspx"));
                }
            }
        }
    }
}