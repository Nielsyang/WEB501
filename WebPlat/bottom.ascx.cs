using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL.Manage;
using BLL.Manage;

namespace WebPlat
{
    public partial class foot : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_click(object sender, EventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if (ClickedButton.ID == "button1")
            {
                Session["name"] = "formula";
                Response.Redirect("Herb_Formula.aspx");
            }
            else if (ClickedButton.ID == "button2")
                Session["name"] = "disease";
            else if (ClickedButton.ID == "button3")
                Session["name"] = "compound";
            Response.Redirect("Herb_and_Compound.aspx");
        }
    }
}