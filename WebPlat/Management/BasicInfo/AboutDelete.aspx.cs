﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPlat.Common;
using BLL.Manage;

namespace WebPlat.Management.BasicInfo
{
    public partial class AboutDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id=Request["Id"];
            if (!String.IsNullOrEmpty(Id))
            {
                int id = int.Parse(Id);
                AboutManager aboutmanager = new AboutManager();
                int res=aboutmanager.DeleteById(id);
                if (res > -1)
                {
                    Response.Write(MessageHelper.showMessage("删除成功！", "About.aspx"));
                }
                else
                {
                    Response.Write(MessageHelper.showMessage("删除失败！","About.aspx"));
                }
            }
        }
    }
}