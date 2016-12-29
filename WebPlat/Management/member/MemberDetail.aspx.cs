using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL.Manage;
using BLL.Manage;

namespace WebPlat.Management.member
{
    public partial class MemberDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id=Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(Id))
            {
                int id = int.Parse(Id);
                MemberBLL  memberBll = new MemberBLL();
                Member member = memberBll.GetByid(id);
                Name.Text = member.name;
                sex.Text = member.sex;
                birthday.Text =Convert.ToString(member.birth);
                degree.Text = member.degree;
                college.Text = member.college;
                major.Text = member.major;
                email.Text = member.email;
                introduce.Value = member.introduce;
                assignment.Value = member.assignment;
                address.Text = member.address;
                addtime.Text =Convert.ToString( member.add_time);
                photo.Src ="../../"+ member.photo;
            }
        }
    }
}