using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL.Manage;
using BLL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.member
{
    public partial class MemberAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addMember(object sender, EventArgs e)
        {
            if(ImageUpload.HasFile)
            {
                string fileName = this.ImageUpload.FileName;//获取上传文件的文件名,包括后缀  
                string ExtenName = System.IO.Path.GetExtension(fileName);//获取扩展名
                string SaveFileName = string.Empty;
                string url = string.Empty;
                if (ExtenName == ".jpg" || ExtenName == ".png" || ExtenName == ".gif")
                {
                    SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath("../upload/member/"), DateTime.Now.ToString("yyyyMMddhhmm") + "_" + fileName);
                    url = "Management/upload/member/" + DateTime.Now.ToString("yyyyMMddhhmm") + "_" + fileName;
                }
                //合并两个路径为上传到服务器上的全路径  
                if (this.ImageUpload.FileContent.Length > 0)
                {
                    try
                    {
                        ImageUpload.SaveAs(SaveFileName);
                        Member member = new Member();
                        member.name = Name.Value;
                        member.sex = sex.SelectedValue;
                        member.birth = Convert.ToDateTime(Birthday.Value);
                        member.degree = degree.SelectedValue;
                        member.college = college.Value;
                        member.major = major.Value;
                        member.email = email.Value;
                        member.photo = url;
                        member.introduce = introduce.Value;
                        member.assignment = assignment.Value;
                        member.add_time = Convert.ToDateTime(AddTime.Value);
                        member.address = hid2.Value;
                        MemberBLL memberBll = new MemberBLL();
                        if (memberBll.Add(member) != null)
                        {
                            Response.Write(MessageHelper.showMessage("添加成功！", "Member.aspx"));
                        }
                        else
                        {
                            Response.Write(MessageHelper.showMessage("添加失败！", "MemberAdd.aspx"));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "警告", "alert('选择要上传的图片为空！');", true);
                }
                float FileSize = (float)System.Math.Round((float)ImageUpload.FileContent.Length / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M  

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "警告", "alert('请选择要上传的图片！');", true);
            }
        }

        protected void Reset(object sender, EventArgs e)
        {
             Name.Value="";
             foreach (ListItem item in sex.Items)
             {
                 if (item.Text == "男")
                 {
                     item.Selected = true;
                 }
             }
             Birthday.Value="";
             college.Value="";
             major.Value="";
             email.Value="";
             introduce.Value="";
             AddTime.Value = "";
        }
    }
}