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
    public partial class add_WebSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddWebSite(object sender, EventArgs e)
        {
            if (ImageUpload.HasFile)
            {
                string fileName =this.ImageUpload.FileName;//获取上传文件的文件名,包括后缀  
                string ExtenName = System.IO.Path.GetExtension(fileName);//获取扩展名
                string SaveFileName=string.Empty;
                string url=string.Empty;
                if(ExtenName==".jpg" || ExtenName==".png" || ExtenName==".gif")
                {
                    SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath("../upload/logo/"), DateTime.Now.ToString("yyyyMMddhhmm") +"_"+fileName);
                    url = "Management/upload/logo/" + DateTime.Now.ToString("yyyyMMddhhmm") + "_" + fileName;
                }
                //合并两个路径为上传到服务器上的全路径  
                if (this.ImageUpload.FileContent.Length> 0)
                {
                    try
                    {
                        ImageUpload.SaveAs(SaveFileName);
                        WebSite  website=new WebSite();
                        WebSiteBLL websiteBll=new WebSiteBLL();
                        website.web_name=websitename.Value;
                        website.link=websiteurl.Value;
                        website.logo=url;
                        if (websiteBll.Add(website) != null)
                        {
                            Response.Write(MessageHelper.showMessage("上传成功！", "WebSite.aspx"));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "警告", "alert('选择要上传的文件为空！');", true);
                }
                float FileSize = (float)System.Math.Round((float)ImageUpload.FileContent.Length / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M  

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "警告", "alert('请选择要上传的文件！');", true);
            }
           }
        }
    }