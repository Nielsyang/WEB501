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
    public partial class EditPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Id=Request.QueryString["Id"];
                if (!string.IsNullOrEmpty(Id))
                {
                    hid.Value = Id;
                    int id = int.Parse(Id);
                    Publication pub = new Publication();
                    PublicationBLL publicationBll = new PublicationBLL();
                    pub=publicationBll.GetByid(id);
                    paperName.Value = pub.paper_name;
                    author.Value = pub.Author;
                    Abstract.Value = pub.Abstract;
                    keyword.Value = pub.keyWord;
                    type.Value = pub.type;
                    level.Value = pub.level;
                    url.Value = pub.url;
                    publish_time.Value =Convert.ToString(pub.publish_time);
                }
            }
        }

        protected void editPublication(object sender, EventArgs e)
        {
            string Id = hid.Value;
            Publication publication = new Publication();
            publication.id = int.Parse(Id);
            publication.paper_name = paperName.Value;
            publication.Author = author.Value;
            publication.Abstract = Abstract.Value;
            publication.keyWord = keyword.Value;
            publication.type = type.Value;
            publication.level = level.Value;
            publication.url = url.Value;
            publication.publish_time =Convert.ToDateTime(publish_time.Value);
            PublicationBLL publicatiobBll = new PublicationBLL();
            int res = publicatiobBll.Update(publication);
            if (res>-1)
            {
                Response.Write(MessageHelper.showMessage("修改成功！", "Publicaiton.aspx"));
            }
            else
            {
                Response.Write(MessageHelper.showMessage("修改失败！", "EditPublication.aspx?Id="+Id));
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            paperName.Value="";
            author.Value="";
            Abstract.Value="";
            keyword.Value="";
            type.Value="";
            level.Value="";
            url.Value="";
            publish_time.Value = "";
        }
    }
}