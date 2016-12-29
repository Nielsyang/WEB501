using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Manage;
using MODEL.Manage;

namespace WebPlat.Management.QuestionManage
{
    public partial class QuestionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id=Request["Id"];
            if (!String.IsNullOrEmpty(Id))
            {
                int id = int.Parse(Id);
                Question question = new Question();
                QuestionManager questionmanager = new QuestionManager();
                question=questionmanager.GetById(id);
                Label1.Text = question.Name;
                Label2.Text = question.Email;
                Label3.Text = question.Subject;
                Label4.Text = question.Message;
                Label5.Text = Convert.ToString(question.Send_time);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("question.aspx");
        }
    }
}