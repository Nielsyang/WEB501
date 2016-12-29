using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL.Manage;
using BLL.Manage;
using WebPlat.Common;

namespace WebPlat.Management.publication
{
    public partial class AddPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addPublication(object sender, EventArgs e)
        {
            Publication publication = new Publication
           {
                    paper_name = paperName.Value,
                    Author = Author.Value,
                    Abstract = Abstract.Value,
                    keyWord = keyword.Value,
                    type = type.Value,
                    level = level.Value,
                    url = url.Value,
                    publish_time = Convert.ToDateTime(publish_time.Value)
            };
            PublicationBLL publicationBll = new PublicationBLL();
            if (publicationBll.Add(publication) != null)
            {
                Response.Write(MessageHelper.showMessage("添加成功！", "Publicaiton.aspx"));
            }
            else
            {
                Response.Write(MessageHelper.showMessage("添加失败！", "AddPublication.aspx"));
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            paperName.Value = "";
            Author.Value = "";
            Abstract.Value = "";
            keyword.Value = "";
            type.Value = "";
            level.Value = "";
            url.Value = "";
            publish_time.Value = "";
        }
    }
}