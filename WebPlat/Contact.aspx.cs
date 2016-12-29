using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL.Manage;
using BLL.Manage;
using WebPlat.Common;

namespace WebPlat
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submitContact(object sender, EventArgs e)
        {
            Question question = new Question();
            question.Name = name.Text;
            question.Email = email.Text;
            question.Subject = subject.Text;
            question.Message = message.Value;
            question.Send_time = DateTime.Now;
            QuestionManager questionManager = new QuestionManager();
            if (questionManager.Add(question) != null)
            {
                Response.Write(MessageHelper.showMessage("问题已提交，我们会尽快回复您！"));
            }

        }
    }
}