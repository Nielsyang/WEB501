using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebPlat.disease
{
    public partial class getCytoscapeWeb : System.Web.UI.Page
    {
        protected string xgmmlurl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string root = Request.Form["root"];
                string second = Request.Form["second"];
                string third = Request.Form["third"];
                string four = Request.Form["four"];
                string LeiXing = Request.Form["LeiXing"];
                string[] directories = Directory.GetDirectories(Server.MapPath("/result_S"));
                string dirname, filename;
                if (second == null && third == null && four == null &&LeiXing == "请选择显示的药物类型")
                {
                    Response.Redirect("/ChooseDiseaseError.aspx");
                }
                if (second != null && third == null && four == null && LeiXing != "请选择显示的药物类型")
                {

                    foreach (string directory in directories)
                    {
                        dirname = directory.Substring(directory.LastIndexOf("\\") + 1);
                        if (("D" + second) == dirname)
                        {
                            string[] dir = Directory.GetFiles(directory);
                            foreach (string file in dir)
                            {
                                filename = file.Substring(file.LastIndexOf("\\") + 1);
                                if ((dirname + LeiXing + ".xgmml") == filename)
                                {
                                    xgmmlurl = dirname + "/" + dirname + LeiXing + ".xgmml";
                                    if (new FileInfo(file).Length <=2048)
                                    {
                                        Response.Redirect("/NotFound.aspx");
                                    }
                                }
                            }
                        }
                    }
                    if (xgmmlurl == null)
                    {
                        Response.Redirect("/NotFound.aspx");
                    }
                }
                if (second != null && third != null && four == null && LeiXing != "请选择显示的药物类型")
                {
                    foreach (string directory in directories)
                    {
                        dirname = directory.Substring(directory.LastIndexOf("\\") + 1);
                        if (("D" + third) == dirname)
                        {
                            string[] dir = Directory.GetFiles(directory);
                            foreach (string file in dir)
                            {
                                filename = file.Substring(file.LastIndexOf("\\") + 1);
                                if ((dirname + LeiXing + ".xgmml") == filename)
                                {
                                    xgmmlurl = dirname + "/" + dirname + LeiXing + ".xgmml";
                                    if (new FileInfo(file).Length <= 2048)
                                    {
                                        Response.Redirect("/NotFound.aspx");
                                    }
                                }
                            }
                        }
                    }
                    if (xgmmlurl == null)
                    {
                        Response.Redirect("/NotFound.aspx");
                    }
                }
                if (second != null && third != null && four != null && LeiXing != "请选择显示的药物类型")
                {
                    foreach (string directory in directories)
                    {
                        dirname = directory.Substring(directory.LastIndexOf("\\") + 1);
                        if (("D" + four) == dirname)
                        {
                            string[] dir = Directory.GetFiles(directory);
                            foreach (string file in dir)
                            {
                                filename = file.Substring(file.LastIndexOf("\\") + 1);
                                if ((dirname + LeiXing + ".xgmml") == filename)
                                {
                                    xgmmlurl = dirname + "/" + dirname + LeiXing + ".xgmml";
                                    if (new FileInfo(file).Length <= 2048)
                                    {
                                        Response.Redirect("/NotFound.aspx");
                                    }
                                }
                            }
                        }
                    }
                    if (xgmmlurl == null)
                    {
                        Response.Redirect("/NotFound.aspx");
                    }
                }
            }
         }
     }
}