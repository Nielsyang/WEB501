using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.QuestionManage
{
    public partial class QuestionDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id=Request["Id"];
            if (!String.IsNullOrEmpty(Id))
            {
                int id = int.Parse(Id);
                QuestionManager questionManager = new QuestionManager();
                int res=questionManager.DeleteById(id);
                if (res > -1)
                {
                    Response.Write(MessageHelper.showMessage("删除成功！", "question.aspx"));
                }
                else
                {
                    Response.Write(MessageHelper.showMessage("删除失败！","question.aspx"));
                }
            }
        }
    }
}