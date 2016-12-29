using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL.Manage;
using BLL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.Download
{
    public partial class Add_download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void upload_Click(object sender, EventArgs e)
        {
            if (AttachFile.HasFile)
            {
                string fileName =this.AttachFile.FileName;//获取上传文件的文件名,包括后缀  
                string ExtenName = System.IO.Path.GetExtension(fileName);//获取扩展名
                string SaveFileName=string.Empty;
                string url=string.Empty;
                if(ExtenName==".jpg" || ExtenName==".png" || ExtenName==".gif")
                {
                    SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath("../upload/image/"), DateTime.Now.ToString("yyyyMMddhhmm") +"_"+fileName);
                    url = "Management/upload/image/" + DateTime.Now.ToString("yyyyMMddhhmm") + "_" + fileName;
                }
                else
                {
                    SaveFileName=System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath("../upload/file/"), DateTime.Now.ToString("yyyyMMddhhmm") +"_"+fileName);
                    url = "Management/upload/file/" + DateTime.Now.ToString("yyyyMMddhhmm") + "_" + fileName;
                }
                //合并两个路径为上传到服务器上的全路径  
                if (this.AttachFile.ContentLength > 0)
                {
                    try
                    {
                        this.AttachFile.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
                        FileDownload filedownload = new FileDownload();
                        filedownload.filename = fileName;
                        filedownload.info = fileDescription.Value;
                        filedownload.url = url;
                        filedownload.add_time = DateTime.Now;
                        DownloadBLL downloadBll = new DownloadBLL();
                        if (downloadBll.Add(filedownload) != null)
                        {
                            Response.Write(MessageHelper.showMessage("上传成功！", "Download.aspx"));
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
                float FileSize = (float)System.Math.Round((float)AttachFile.ContentLength / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M  

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "警告", "alert('请选择要上传的文件！');", true);
            }
        }  
     }
 }
