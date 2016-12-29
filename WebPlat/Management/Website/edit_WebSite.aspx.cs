using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL.Manage;
using BLL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.Website
{
    public partial class edit_WebSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Id = Request.QueryString["Id"];
                if (!String.IsNullOrEmpty(Id))
                {
                    hid.Value = Id;
                    int id = int.Parse(Id);
                    WebSite website = new WebSite();
                    WebSiteBLL websiteBll = new WebSiteBLL();
                    website = websiteBll.GetByid(id);
                    websiteName.Value = website.web_name;
                    websiteUrl.Value = website.link;
                    websiteImage.Src = "../../" + website.logo;
                }
            }
        }

        protected void editWebSite(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = this.FileUpload1.FileName;//获取上传文件的文件名,包括后缀  
                string ExtenName = System.IO.Path.GetExtension(fileName);//获取扩展名
                string SaveFileName = string.Empty;
                string url = string.Empty;
                if (ExtenName == ".jpg" || ExtenName == ".png" || ExtenName == ".gif")
                {
                    SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath("../upload/logo/"), DateTime.Now.ToString("yyyyMMddhhmm") + "_" + fileName);
                    url = "Management/upload/logo/" + DateTime.Now.ToString("yyyyMMddhhmm") + "_" + fileName;
                }
                //合并两个路径为上传到服务器上的全路径  
                if (this.FileUpload1.FileContent.Length > 0)
                {
                    try
                    {
                        string Id = hid.Value;
                        if (!string.IsNullOrEmpty(Id))
                        {
                            int id = int.Parse(Id);
                            FileUpload1.SaveAs(SaveFileName);
                            WebSite website = new WebSite();
                            website.id = id;
                            website.web_name = websiteName.Value;
                            website.link = websiteUrl.Value;
                            website.logo = url;
                            WebSiteBLL websiteBll = new WebSiteBLL();
                            int res=websiteBll.Update(website);
                            if (res > -1)
                            {
                                Response.Write(MessageHelper.showMessage("修改成功！", "WebSite.aspx"));
                            }
                            else
                            {
                                Response.Write(MessageHelper.showMessage("修改失败！", "edit_WebSite.aspx?Id="+id));
                            }
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
                float FileSize = (float)System.Math.Round((float)FileUpload1.FileContent.Length / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M  

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "警告", "alert('请选择要上传的图片！');", true);
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            websiteName.Value = "";
            websiteUrl.Value = "";
            websiteImage.Src = "";
        }
    }
}